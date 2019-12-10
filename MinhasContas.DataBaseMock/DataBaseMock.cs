using System.Collections.Generic;
using System;

namespace MinhasContas.DataBaseMock
{
    public class DataBaseMock<T> where T : BaseEntity
    {
        private readonly List<T> dataSet;
        

        public DataBaseMock(List<T> dataSet)
        {
            this.dataSet = dataSet;

        }

        public T Get(long id)
        {
            return dataSet.Where(ent => ent.Id == id).FirstOrDefault();
        }
        public bool insert(T entity)
        {
            dataSet.Add(entity);
            return true;
        }
        public bool Update(T entity)
        {
            dataSet.ForEach(ent =>
            {
                if(entity.Id == ent.Id)
                {
                    dataSet.Remove(ent);
                    dataSet.Add(entity);
                }
            });
            return true;
        }
        public bool Delete(long id)
        {
            dataSet.RemoveAll(ent => ent.Id == id);
            return true;
        }
       
        public List<T> GetList()
        {
            return dataSet;
        }


    }
}
