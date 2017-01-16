using NFPush.Model.NFe.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace NFPush.Model
{
    public interface IDataService
    {
        #region Ref Push

        #region · Properties ·
        void SalvaDFe(DFe _dfe);
        #endregion

        #region · Constructors ·
        #endregion

        #endregion

        #region Ref NFDBase

        ObservableCollection<DFe> GetDFs();
        ObservableCollection<DFeObj> GetDFsObj();
        #endregion
    }
}
