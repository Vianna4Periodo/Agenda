using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB
{
    public class DbFactory
    {
        private static DbFactory _instance = null;

        private DbFactory()
        {
            
        }

        public static DbFactory Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DbFactory();
                }

                return _instance;
            }
        }

        private void Connection()
        {
            try
            {
                var server = "localhost";
                var port = "3306";
                var dbName = "db_agenda";
                var user = "root";
                var psw = "aluno";
                var stringConnection = "Persist Security Info=False;" +
                                       "server =" + server +
                                       ";port=" + port +
                                       ";database=" + dbName +
                                       ";uid=" + user +
                                       ";pwd=" + psw;

                try
                {
                    var mysql = new MySqlConnection(stringConnection);
                    mysql.Open();

                    if(mysql.State == ConnectionState.Open)
                    {
                        mysql.Close();
                    }
                }
                catch
                {

                }
                ConfigureNHibernate(stringConnection);
            }catch(Exception ex)
            {
                throw new Exception("Cannot connect to database. Error: ", ex);
            }
        }

        private void ConfigureNHibernate(string stringConnection)
        {
            try
            {
                //using NHibernate.cfg
                var config = new Configuration();

                //Configuracao do NHibernate com o MySQL
                config.DataBaseIntegration(i =>
                {
                    //Dialeto do banco
                    i.Dialect<NHibernate.Dialect.MySQLDialect>();
                    //Conexao string
                    i.ConnectionString = stringConnection;
                    //Drive de conexao com o banco
                    i.Driver<NHibernate.Driver.MySqlDataDriver>();
                    //Provedor de conexao do MySQL
                    i.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
                    //Gera log dos sql executados no console
                    i.LogSqlInConsole = true;
                    //descomentar caso queira visualizar o log de sql formatado no console
                    i.LogFormattedSql = true;
                    //cria schema do banco de dados sempre que a configuration for utilizada
                    i.SchemaAction = SchemaAutoAction.Update;
                });
            }
            catch(Exception ex)
            {
                throw new Exception("Cannot configure NHibernate. Error: ", ex);
            }
        }
    }
}
