using HtmlAgilityPack;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://www.sbs.gob.pe/app/pp/sistip_portal/paginas/publicacion/tipocambiopromedio.aspx";
        using HttpClient client = new HttpClient();
        var response = await client.GetStringAsync(url);

        if(response != null)
        {
            var html = new HtmlDocument();
            html.LoadHtml(response);
     
            var table = html.DocumentNode.SelectSingleNode("//table[@id='ctl00_cphContent_rgTipoCambio_ctl00']");
            var row = table.SelectSingleNode(".//tr[@id='ctl00_cphContent_rgTipoCambio_ctl00__0']");
            var coinName = row.SelectSingleNode(".//td[@class='APLI_fila3']");
            var coinAmmount = row.SelectNodes(".//td[@class='APLI_fila2']");
            var coin = coinName.InnerText.Trim();
            var buy = coinAmmount[0].InnerText;
            var sale = coinAmmount[1].InnerText;
            Console.WriteLine($"Moneda : {coin}\nCompra : {buy}\nVenta: {sale}");
        }
    }
}

