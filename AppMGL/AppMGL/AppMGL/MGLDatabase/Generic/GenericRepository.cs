using AppMGL.MGLDatabase.Database;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppMGL.MGLDatabase.Generic
{
    public class GenericRepository<T> where T : class
    {
        public static object locker = new object();
        private SQLiteConnection sqlConnection;

        public GenericRepository()
        {
            this.sqlConnection = Xamarin.Forms.DependencyService.Get<IDatabase>().DbConnection();
        }

        public string Add(T t)
        {
            lock (locker)
            {
                string erro = "";
                try
                {
                    var gravou = sqlConnection.Insert(t);
                    if (gravou == 0)
                    {
                        erro = "Erro ao gravar";
                    }
                }
                catch (SQLiteException sex)
                {
                    erro = sex.InnerException == null ? sex.Message : sex.InnerException.Message;
                }
                catch (Exception ex)
                {
                    erro = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return erro;
            }
        }

        public string Update(T t)
        {
            lock (locker)
            {
                string erro = "";
                try
                {
                    var gravou = sqlConnection.Update(t);
                    if (gravou == 0)
                    {
                        erro = "Erro ao gravar";
                    }
                }
                catch (SQLiteException sex)
                {
                    erro = sex.InnerException == null ? sex.Message : sex.InnerException.Message;
                }
                catch (Exception ex)
                {
                    erro = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return erro;
            }
        }
        public string Detele(T t)
        {
            lock (locker)
            {
                string erro = "";
                try
                {
                    var gravou = sqlConnection.Delete(t);
                    if (gravou == 0)
                    {
                        erro = "Erro ao deletar";
                    }
                }
                catch (SQLiteException sex)
                {
                    erro = sex.InnerException == null ? sex.Message : sex.InnerException.Message;
                }
                catch (Exception ex)
                {
                    erro = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return erro;
            }
        }

        public string DeleteAll()
        {
            lock (locker)
            {
                string erro = "";
                try
                {
                    var gravou = sqlConnection.DeleteAll<T>();
                    if (gravou == -1)
                    {
                        erro = "Erro ao deletar";
                    }
                }
                catch (SQLiteException sex)
                {
                    erro = sex.InnerException == null ? sex.Message : sex.InnerException.Message;
                }
                catch (Exception ex)
                {
                    erro = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                }

                return erro;
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> where)
        {
            lock (locker)
            {
                var ts = sqlConnection.Table<T>().Where(where);
                return ts;
            }
        }

        public IEnumerable<T> GetAll()
        {
            lock (locker)
            {
                var ts = sqlConnection.Table<T>();
                return ts;
            }
        }
    }
}



