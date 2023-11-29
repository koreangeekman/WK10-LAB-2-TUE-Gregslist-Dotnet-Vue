namespace Gregslist.Services;

public class HousesService(HousesRepo housesRepo)
{
  internal List<House> GetHouses()
  { return housesRepo.GetHouses(); }

  internal House GetHouseById(int houseId)
  { return housesRepo.GetHouseById(houseId); }

  internal House CreateHouse(House houseData)
  { return housesRepo.CreateHouse(houseData); }

  internal string DeleteHouse(int houseId)
  {
    housesRepo.DeleteHouse(houseId);
    return "House demolished";
  }

  internal House UpdateHouse(int houseId, House houseData)
  {
    House house = GetHouseById(houseId);

    house.Title = houseData.Title ?? house.Title;
    house.Description = houseData.Description ?? house.Description;
    house.Year = houseData.Year ?? house.Year;
    house.Price = houseData.Price ?? house.Price;
    house.Bedrooms = houseData.Bedrooms ?? house.Bedrooms;
    house.Bathrooms = houseData.Bathrooms ?? house.Bathrooms;
    house.ImgUrl = houseData.ImgUrl ?? house.ImgUrl;

    return housesRepo.UpdateHouse(house);
  }
}