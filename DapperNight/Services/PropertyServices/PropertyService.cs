using Dapper;
using DapperNight.Context;
using DapperNight.Dtos.PropertyDtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperNight.Services.PropertyServices
{
    public class PropertyService : IPropertyService
    {
        private readonly DapperContext _context;

        public PropertyService(DapperContext context)
        {
            _context = context;
        }

        public async Task<ResultPropertyWithImagesDto> GetPropertiesByIdAsync(FilterPropertyByIdDto filterPropertyByIdDto)
        {
            var sql = @"
                SELECT p.Id, p.City, p.Status, p.Price, p.Area, p.RoomCount, p.CategoryId, s.ImageUrl
                FROM TblProperty p
                LEFT JOIN TblSlider s ON p.Id = s.PropertyId
                WHERE p.Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", filterPropertyByIdDto.Id);

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultPropertyDto>(sql, parameters);

                var property = result.FirstOrDefault();
                if (property == null)
                {
                    return null;
                }



                var images = result.Select(x => x.ImageUrl).ToList();

                return new ResultPropertyWithImagesDto
                {
                    Id = property.Id,
                    City = property.City,
                    Status = property.Status,
                    Price = property.Price,
                    Area = property.Area,
                    RoomCount = property.RoomCount,
                    CategoryId = property.CategoryId,
                    ImageUrls = images
                };
            }
        }

        public async Task<List<ResultPropertyDto>> GetPropertiesWithFilterAsync(FilterPropertyDto filterPropertyDto)
        {
            var sql = @"
                SELECT p.Id, p.City, p.Status, p.Price, p.Area, p.RoomCount, p.CategoryId, s.ImageUrl
                FROM TblProperty p
                LEFT JOIN (
                    SELECT PropertyId, MIN(Id) AS MinId
                    FROM TblSlider
                    GROUP BY PropertyId
                ) first_image ON p.Id = first_image.PropertyId
                LEFT JOIN TblSlider s ON first_image.MinId = s.Id
                WHERE 1=1"; // Basit bir temel sorgu
            var parameters = new DynamicParameters();
            // FilterPropertyDto nesnesinin null olup olmadığını kontrol et
            if (filterPropertyDto != null)
            {
                if (!string.IsNullOrEmpty(filterPropertyDto.City))
                {
                    sql += " AND City = @City";
                    parameters.Add("@City", filterPropertyDto.City);
                }

                if (!string.IsNullOrEmpty(filterPropertyDto.Status))
                {
                    sql += " AND Status = @Status";
                    parameters.Add("@Status", filterPropertyDto.Status);
                }

                if (filterPropertyDto.MinPrice.HasValue)
                {
                    sql += " AND Price >= @MinPrice";
                    parameters.Add("@MinPrice", filterPropertyDto.MinPrice);
                }

                if (filterPropertyDto.MaxPrice.HasValue)
                {
                    sql += " AND Price <= @MaxPrice";
                    parameters.Add("@MaxPrice", filterPropertyDto.MaxPrice);
                }

                if (filterPropertyDto.MinRoomCount.HasValue)
                {
                    sql += " AND RoomCount >= @MinRoomCount";
                    parameters.Add("@MinRoomCount", filterPropertyDto.MinRoomCount);
                }

                if (filterPropertyDto.MaxRoomCount.HasValue)
                {
                    sql += " AND RoomCount <= @MaxRoomCount";
                    parameters.Add("@MaxRoomCount", filterPropertyDto.MaxRoomCount);
                }

                if (filterPropertyDto.MinArea.HasValue)
                {
                    sql += " AND Area >= @MinArea";
                    parameters.Add("@MinArea", filterPropertyDto.MinArea);
                }

                if (filterPropertyDto.MaxArea.HasValue)
                {
                    sql += " AND Area <= @MaxArea";
                    parameters.Add("@MaxArea", filterPropertyDto.MaxArea);
                }

                if (filterPropertyDto.CategoryId.HasValue)
                {
                    sql += " AND CategoryId = @CategoryId";
                    parameters.Add("@CategoryId", filterPropertyDto.CategoryId);
                }
            }

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyDto>(sql, parameters);
                return values.ToList();
            }
        }

    }
}
