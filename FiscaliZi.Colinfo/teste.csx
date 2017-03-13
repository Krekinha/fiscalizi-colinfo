#r ".\bin\Debug\FiscaliZi.Colinfo.exe"
using FiscaliZi.Colinfo.Model;

var items = new List<Item>
            {
                new Item{ Produto = "900090", QntCX = 55, ValorTotal = 300},
                new Item{ Produto = "900090", QntCX = 62, ValorTotal = 20},
                new Item{ Produto = "900023", QntCX = 25, ValorTotal = 520},
                new Item{ Produto = "900023", QntCX = 25, ValorTotal = 1200}
            };

int points = 1000;
var ranks = Enumerable.Range(1, items.Count);
var result = items.OrderByDescending(x => x.ValorTotal).ThenBy(x => x.Produto).Zip(ranks, (x, y) => new { x.Produto, x.ValorTotal, x.QntCX, rank = y });
var above = result.Where(x => x.ValorTotal >= points).OrderBy(x => x.ValorTotal).Take(6);
var below = result.Where(x => x.ValorTotal < points).OrderByDescending(x => x.ValorTotal).Take(4);
var filtered = above.Union(below).OrderByDescending(x => x.ValorTotal).ThenBy(x => x.Produto);

foreach (var v in filtered)
{
    var res = $"{v.QntCX} | {v.Produto} | {v.ValorTotal}";
    Console.WriteLine(res);
}
