using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace pegabicho.domain.Entities.Base {
    public class EntityBase {
        #region [ attributes ]

        [Key]
        public string Id { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        #endregion

        #region [ ctor ]

        protected EntityBase() {
            Id = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
            CreatedAt = DateTimeOffset.UtcNow;
        }

        #endregion

        #region [ methods ]

        /// <summary>
        /// Return a new custom guid with base in the size from length atribute
        /// </summary>
        /// <param name="length">Use to substring length</param>
        /// <returns></returns>
        public static string CustomHash(int length = 0) {
            return Guid.NewGuid().ToString().ToUpper().Replace("-", "").Substring(0, length);
        }

        public static string LetterHash(int length) {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #endregion
    }
}
