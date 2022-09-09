using System;
using System.Data.SqlClient;

namespace Medieval_War.Database
{
    internal class DataBase
    {
        private Singleton podkluchenie;
        private SqlPodkluchenie sqlPodkluchenie;

        public SqlPodkluchenie SqlPodkluchenie
        {
            get { return sqlPodkluchenie; }
            set { sqlPodkluchenie = value; }
        }
        public Singleton Podkluchenie

        {
            get { return podkluchenie; }
            set { podkluchenie = value; }
        }

        public DataBase(Singleton podkluchenie)
        {
            this.Podkluchenie = podkluchenie;
            this.SqlPodkluchenie = new SqlPodkluchenie(Podkluchenie.Podkluchenie);
        }

        public SqlComandi Request(string sqlText)
        {
            using (SqlComandi command = new SqlComandi(sqlText, this.SqlPodkluchenie))
                return command;
        }
    }
}