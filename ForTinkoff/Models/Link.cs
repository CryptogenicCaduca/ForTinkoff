using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;

namespace ForTinkoff.Models
{
    public class Link
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public DateTime InitDateTime { get; set; }
        public int Jumps { get; set; }

        static readonly char[] alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        /// <summary>
        /// Increments link's shortUrl by one symbol on alphabet
        /// </summary>
        /// <returns>New link with proper DateTime and incremented ShortUrl</returns>
        public static Link operator +(Link link, int a)
        {
            StringBuilder shortUrl = new StringBuilder();
            shortUrl.Append(link?.ShortUrl ?? "http://localhost:9527/Api/Link/");

            int i = shortUrl.Length - 1;
            while (i >= 0 && shortUrl[i] == 'z' && shortUrl[i] != '/')
            {
                shortUrl[i] = '0';
                i--;
            }
            if (i == -1 || shortUrl[i] == '/')
                shortUrl.Insert(i+1, '0');
            else
                shortUrl[i] = alphabet[Array.IndexOf(alphabet, shortUrl[i]) + 1];


            return new Link
            {
                InitDateTime = DateTime.Now,
                ShortUrl = shortUrl.ToString()
            };
        }
    }
}