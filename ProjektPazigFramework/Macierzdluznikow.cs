using ProjektPazigFramework.Model;
using ProjektPazigFramework.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPazigFramework
{
    public class Macierzdluznikow
    {
        static public int idgrupy; //do pobrania z zew
        public  List<Expense> listawydatkowgrupy; // co (nazwa,id), ile, kto zapłacił
        public List<Debtor> listadluznikow;// co(id), dla kogo zaplacone
        public List<Debtor> listadluznikow2;
        public List<Debtor> podlistadluznikow;
        static public List<Person> listaosob;
        public int[,] graph;
        static public int iloscosob;

        static ApplicationDb _db = new ApplicationDb();

        public  Macierzdluznikow(int id)
        {
            idgrupy = id;
            listawydatkowgrupy = _db.Expenses.Where(x => x.GroupId == idgrupy).Select(x => x).ToList();
            listaosob = _db.People.Where(x => x.GroupId == idgrupy).Select(x => x).ToList();
            iloscosob = listaosob.Count;
            graph = new int[iloscosob, iloscosob];
            for (int i = 0; i < iloscosob; i++)
            {
                for (int j = 0; j < iloscosob; j++)
                {
                    graph[i,j] = 0;
                }
            }

            listadluznikow= _db.Debtors.Select(x => x).ToList();
            listadluznikow2 = new List<Debtor>();
            for (int i = 0; i < _db.Debtors.Count(); i++)
            {
                for (int j = 0; j < listawydatkowgrupy.Count; j++)
                {
                    if (listadluznikow[i].ExpenseId == listawydatkowgrupy[j].ExpenseId)
                    {
                        listadluznikow2.Add(listadluznikow[i]);
                    }
                }
                
            }
            int idwydatku;
            int iloscdorozliczenia;
            int czescdosplaty;
            int kto;
            int komu;
            for (int i = 0; i < listawydatkowgrupy.Count; i++)
            {
                idwydatku = listawydatkowgrupy[i].ExpenseId;
                podlistadluznikow = listadluznikow.Where(x => x.ExpenseId == idwydatku).ToList();
                iloscdorozliczenia = podlistadluznikow.Count;
                czescdosplaty = listawydatkowgrupy[i].Amount / iloscdorozliczenia;
                kto = listawydatkowgrupy[i].PersonId;
                kto = listaosob.Where(x => x.PersonId == kto).Select(x => x.NrIndexInGroup).ToList().First()-1;
                for (int j = 0; j < iloscdorozliczenia; j++)
                {
                    komu = podlistadluznikow[j].PersonId;
                    komu = listaosob.Where(x => x.PersonId == komu).Select(x => x.NrIndexInGroup).ToList().First()-1;

                    if(kto != komu)
                    {
                        graph[komu, kto] = graph[komu, kto]+ czescdosplaty;
                        
                    }
                   
                    
                }
            }


        }



        static int getMin(int[] arr)
        {
            int minInd = 0;
            for (int i = 1; i < iloscosob; i++)
                if (arr[i] < arr[minInd])
                    minInd = i;
            return minInd;
        }
        static int getMax(int[] arr)
        {
            int maxInd = 0;
            for (int i = 1; i < iloscosob; i++)
                if (arr[i] > arr[maxInd])
                    maxInd = i;
            return maxInd;
        }

        static int minOf2(int x, int y)
        {
            return (x < y) ? x : y;
        }
        static void minCashFlowRec(int[] amount, List<Debet> lista)
        {
 
            int mxCredit = getMax(amount), mxDebit = getMin(amount);

            if (amount[mxCredit] == 0 &&
                amount[mxDebit] == 0)
                return;

            int min = minOf2(-amount[mxDebit], amount[mxCredit]);
            amount[mxCredit] -= min;
            amount[mxDebit] += min;
            string imie1 = listaosob.Where(x => x.NrIndexInGroup == mxDebit + 1).Select(x => x.Name).ToList().First().ToString(); 
            string imie2 = listaosob.Where(x => x.NrIndexInGroup == mxCredit + 1).Select(x => x.Name).ToList().First().ToString();
            Debet d = new Debet { GroupId = idgrupy, Amount = min, WhoId = mxDebit+1, WhoName= imie1, ForWhoId = mxCredit+1, ForWhoName=imie2};
            lista.Add(d);
            _db.Debets.Add(d);
            _db.SaveChanges();


            minCashFlowRec(amount, lista);
        }
        static void minCashFlow(int[,] graph, List<Debet> lista)
        {
            int[] amount = new int[iloscosob];
            for (int p = 0; p < iloscosob; p++)
                for (int i = 0; i < iloscosob; i++)
                    amount[p] += (graph[i, p] - graph[p, i]);

            minCashFlowRec(amount, lista);
        }
        public void ObliczMacierz(int[,] macierz)
        {
           
            List<Debet> listadlugow = new List<Debet>();

            minCashFlow(macierz, listadlugow);

        }

    }
}
