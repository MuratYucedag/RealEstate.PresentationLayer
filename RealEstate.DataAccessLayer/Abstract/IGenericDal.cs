using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DataAccessLayer.Abstract
{

    //IGenericDal T değişkeni alacak. T ifadesi entitileri yanı class'ları kaşılıyor
    //where T : class >> T değeri sadece bir class olabilir demek için yapıladı
    public interface IGenericDal<T> where T : class
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        List<T> GetList();

        T GetByID(int id);

    }
}
