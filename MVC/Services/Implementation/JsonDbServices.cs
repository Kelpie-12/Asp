using System.Text.Json;
using System.Threading.Tasks;
using MVC.Model.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Services.Implementation
{
    public class JsonDbServices : IJsonDbServices
    {
        private readonly Dictionary<long, UserReview> _review;
        private readonly string pach = $"../MVC/Model/JsonUserReview/";
        public JsonDbServices()
        {
            _review = new Dictionary<long, UserReview>();
        }
        public bool AddNewUserReviewToJSON(UserReview review)
        {            
            try
            {
                UserReview tmp = new UserReview(review);
                Console.WriteLine(tmp.Id);
                Save(tmp);
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public bool DeleteUserReviewToJSON(UserReview review)
        {
            try
            {
                _review.Remove(review.Id); 
                System.IO.File.Delete(pach + $"{review.Id}.json");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditUserReviewToJSON(UserReview review)
        {
            try
            {
                Save(review);
                _review.Remove(review.Id);
                _review.Add(review.Id, review);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<UserReview> GetUserReviewToJSON()
        {
            DirectoryInfo directory = new DirectoryInfo(pach);
            foreach (var item in directory.GetFiles())
            {
                if (Path.GetExtension(item.FullName) == ".json")
                {
                    var serializedReview = File.ReadAllText(item.FullName);
                    UserReview tmp = JsonSerializer.Deserialize<UserReview>(serializedReview);
                    if (!_review.ContainsKey(tmp.Id))
                    {
                        _review.Add(tmp.Id, tmp);                        
                    }                    
                }
            }
            return _review.Values.ToList<UserReview>();
        }

        public List<UserReview> GetUserReviewToJSONById(long id)
        {
            _review.Clear();
            DirectoryInfo directory = new DirectoryInfo(pach);
            foreach (var item in directory.GetFiles())
            {
                if (Path.GetExtension(item.FullName) == ".json")
                {
                    var serializedReview = File.ReadAllText(item.FullName);
                    UserReview tmp = JsonSerializer.Deserialize<UserReview>(serializedReview);
                    if ((!_review.ContainsKey(tmp.Id)) && tmp.IdProduct == id)
                    {
                        _review.Add(tmp.Id, tmp);
                    }
                }
            }
            return _review.Values.ToList<UserReview>();
        }

        private void Save(UserReview review)
        {
            var serializedReview = JsonSerializer.Serialize(review, new JsonSerializerOptions { WriteIndented = true }); ;
          //  Console.WriteLine("C:\\Users\\roman\\source\\repos\\Asp\\MVC\\Model\\JsonUserRevuew");
            File.WriteAllText(pach+$"{review.Id}.json", serializedReview);
        }
    }
}
