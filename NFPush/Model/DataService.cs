using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NFPush.Model.NFe.Classes;
using NFPush.Model.NFe.Classes.Informacoes;
using NFPush.Model.NFe.Classes.Informacoes.Detalhe;
using NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NFPush.Utils;
using System.Windows;

namespace NFPush.Model
{
    public class DataService : IDataService
    {
        readonly NFPContext context;

        public DataService()
        {
            context = new NFPContext();
        }

        #region Ref Push
        public void SalvaDFe(DFe _dfe)
        {
            try
            {
                context.DFes.Add(_dfe);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                var msg = "";
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.InnerException != null)
                        msg = ex.InnerException.Message;
                    else
                        msg = ex.Message;
                    Funcoes.Mensagem(msg, "Erro", MessageBoxButton.OK);
                }
            }

        }
        #endregion

        #region Ref NFDBase

        public ObservableCollection<DFe> GetDFs()
        {
            ObservableCollection<DFe> DFs = new ObservableCollection<DFe>();

            var vends = context.DFes;

            foreach (var item in vends)
            {
                DFs.Add(item);
            }

            return DFs;
        }

        public ObservableCollection<DFeObj> GetDFsObj()
        {
            return new ObservableCollection<DFeObj>();
        }
        #endregion
    }
}