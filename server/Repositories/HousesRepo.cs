namespace Gregslist.Repositories;

public class HousesRepo(IDbConnection db)
{
  internal List<House> GetHouses()
  {
    string sql = "SELECT * FROM houses;";
    return db.Query<House>(sql).ToList();
  }

  internal House GetHouseById(int houseId)
  {
    string sql = "SELECT * FROM houses WHERE id = @houseId;";
    return db.QueryFirstOrDefault<House>(sql, new { houseId });
  }

  internal House CreateHouse(House houseData)
  {
    string sql = @"
    INSERT INTO houses (title,description,year,price,bedrooms,bathrooms,imgUrl)
    VALUES(@Title,@Description,@Year,@Price,@Bedrooms,@Bathrooms,@ImgUrl);

    SELECT * FROM houses WHERE id = LAST_INSERT_ID();";
    return db.QueryFirstOrDefault<House>(sql, houseData);
  }

  internal void DeleteHouse(int houseId)
  {
    string sql = "DELETE FROM houses WHERE id = @houseId LIMIT = 1;";
    db.Query(sql, new { houseId });
  }

  internal House UpdateHouse(House houseData)
  {
    string sql = @"UPDATE houses
    SET
    title = @Title,
    description = @Description,
    year = @Year,
    price = @Price,
    bedrooms = @Bedrooms,
    bathrooms = @Bathrooms,
    imgUrl = @ImgUrl
    WHERE id = @Id
    ;";
    return db.QueryFirstOrDefault<House>(sql, houseData);
  }

}