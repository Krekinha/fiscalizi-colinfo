using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NFPush.Model;
using NFPush.Model.NFe.Classes;
using NFe.Utils;
using NFe.Classes.Servicos.DistribuicaoDFe;

namespace NFPush.Design
{
    public class DesignDataService : IDataService
    {
        public ObservableCollection<DFe> GetDFs()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<DFeObj> GetDFsObj()
        {
            var DFs = new ObservableCollection<DFeObj>();

            var retorno = FuncoesXml.XmlStringParaClasse<retDistDFeInt>(Properties.Resources.xmlDB);

            var lotes = retorno.loteDistDFeInt;

            for (int i = 0; i < lotes.Length; i++)
            {

                string conteudo = Compressao.Unzip(lotes[i].XmlNfe);

                if (lotes[i].schema.Contains("procNFe_v"))
                {
                    DFs.Add(
                        new DFeObj
                        {
                            NSU = lotes[i].NSU,
                            schema = lotes[i].schema,
                            xmlNFe = conteudo,
                            nfeObj = FuncoesXml.XmlStringParaClasse<nfeProc>(conteudo)
                            
                        });
                }
                else if (lotes[i].schema.Contains("resNFe_v"))
                {
                    var resNF = FuncoesXml.XmlStringParaClasse<NFe.Classes.Servicos.DistribuicaoDFe.Schemas.resNFe>(conteudo);
                    nfeProc nfProc = new nfeProc
                    {
                        NFe = new NFeObj
                        {
                            infNFe = new Model.NFe.Classes.Informacoes.infNFe
                            {
                                emit = new Model.NFe.Classes.Informacoes.Emitente.emit
                                {
                                    xNome = resNF.xNome,
                                    CNPJ = resNF.CNPJ.ToString()
                                },
                                ide = new Model.NFe.Classes.Informacoes.Identificacao.ide
                                {
                                    dhEmi = resNF.dhEmi
                                },
                                total = new Model.NFe.Classes.Informacoes.Total.total
                                {
                                    ICMSTot = new Model.NFe.Classes.Informacoes.Total.ICMSTot
                                    {
                                        vNF = resNF.vNF
                                    }
                                }
                            }
                        },
                        protNFe = new Model.NFe.Classes.Protocolo.protNFe
                        {
                            infProt = new Model.NFe.Classes.Protocolo.infProt
                            {
                                dhRecbto = resNF.dhRecbto

                            }
                        }
                    };
                    DFs.Add(
                        new DFeObj
                        {
                            NSU = lotes[i].NSU,
                            schema = lotes[i].schema,
                            xmlNFe = conteudo,
                            nfeObj = nfProc
                        });
                }
            }
            return DFs;
        }

        public void SalvaDFe(DFe _dfe)
        {
            throw new NotImplementedException();
        }

        public void SalvaNFS(List<nfeProc> nfs)
        {
            throw new NotImplementedException();
        }
    }
}