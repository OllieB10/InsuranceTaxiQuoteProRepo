using DataAccess.Interfaces;
using DataAccess.Enums;

namespace DataAccess.RatingTable
{
    public class CoverTypeTable : ICoverTypeTable
    {
        #region Cover Type
        public Dictionary<string, decimal> GetCoverTable()
        {
            var coverTable = new Dictionary<string, decimal>
            {
                {$"{CoverType.Comprehensive}", 1.10M},
                {$"{CoverType.ThirdPartyFireAndTheft}", 1.10M},
                {$"{CoverType.ThirdPartyOnly}", 1.10M}
            };

            return coverTable;
        }

        #endregion

    }
}
