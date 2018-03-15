using System;
using System.IO;
using CarParser0.DTO;

namespace CarParser0.DataStore
{
    public class StoreToHtml : IDataStore
    {
        private String path;

        private String html = "<!DOCTYPE html>" +
            "<html lang=\"en\">" +
            "<head>" +
            "<meta charset=\"UTF-8\">" +
            "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
            "<link href=\"style.css\" rel=\"stylesheet\">" +
            "<title>Parsed Result</title>" +
            "</head><body><table><caption>Results:</caption><tr><th>Id</th><th>Site</th><th>Qty</th><th>Price</th></tr>|data|</table></body></html>";

        public StoreToHtml(String path)
        {
            this.path = path;

            File.WriteAllText(path, html);
        }

        public void Save(SiteInfo info)
        {
            String file = File.ReadAllText(path);

            var newLine = String.Format("<tr>" +
                                            "<td>{0}</td>" +
                                            "<td>{1}</td>" +
                                            "<td>{2}</td>" +
                                            "<td>{3}</td>" +
                                        "</tr>|data|",
                                        info.id, info.site, info.quantity, info.price);

            var content = file.Replace("|data|", newLine);

            File.WriteAllText(path, content);
        }
    }
}
