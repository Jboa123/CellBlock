using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using CellBlockLibrary;


namespace _7by7
{
    public static class DataAccess
    {


        public static List<int> GetUniqueIDList()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionHelper.CnnVal("SevbySevDB")))
            {
                List<int> dataList  = new List<int>();
                dataList = connection.Query<int>("dbo.GetUnique_ids").ToList();
                return dataList;
            }
        }

        public static void SaveDataToDB(List<DBData> dataList)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionHelper.CnnVal("SevbySevDB")))
            {
                foreach (DBData data in dataList)
                {
                    connection.Execute("dbo.SaveData @Puzzle_id, @Block_id, @Area, @DefCell_XPos, @DefCell_YPos, @TopLeft_XPos, @TopLeft_YPos, @X_Dimension, @Y_Dimension", data);
                }
            }
        }
            
        public static List<DBData> LoadCaseFromDB(int PuzzleID)
        {
            List<DBData> dataList = new List<DBData>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionHelper.CnnVal("SevbySevDB")))
            {
                dataList = connection.Query<DBData>("dbo.RetrieveData @Puzzle_id", new { Puzzle_id = PuzzleID }).ToList();
                
            }
            return dataList;
        }
    }
    
    
}
