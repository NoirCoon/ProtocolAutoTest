using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolAutoTest
{
    

    public class TemplateTables
    {
        
		public Table[] tables = new Table[10];//массив таблиц макс 10
        public int[] index;//массив для индексов используемых таблиц
        public int GetCountTable()//получение количества таблицы


        {
            int count = 0;
            foreach (Table table in tables)
            {
                if (table != null)
                {
                    count++;
                }
            }
            return count;
        }
    }
}

