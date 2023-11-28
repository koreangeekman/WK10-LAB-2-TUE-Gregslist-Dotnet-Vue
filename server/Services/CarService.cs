namespace Gregslist.Services;

public class CarService(CarRepository carRepository)
{
  internal List<Car> GetCars()
  { return carRepository.GetCars(); }

  internal Car GetCarById(int carId)
  {
    Car car = carRepository.GetCarById(carId);
    if (car == null) { throw new Exception($"Invalid Car Id: {carId}"); }
    return car;
  }

  internal Car CreateCar(Car carData)
  { return carRepository.CreateCar(carData); }

  internal string DeleteCar(int carId)
  {
    carRepository.DeleteCar(carId);
    return "Car has been deleted";
  }

  internal Car UpdateCar(Car carData)
  {
    Car car = carRepository.UpdateCar(carData);
    return car;
  }
}