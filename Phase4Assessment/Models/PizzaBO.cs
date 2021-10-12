using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phase4Assessment.Models
{
    public class PizzaBO
    {
        public static List<PizzaModel> pizzas;
        public PizzaBO()
        {
            pizzas = new List<PizzaModel>
            {
                new PizzaModel{
                    Id=1,
                    Name="Margherita",
                    Size="Medium",
                    Description="A hugely popular margherita, with a deliciously tangy single cheese topping",
                    Price=250,
                    ImageUrl="001.jpg"
                },
                new PizzaModel{
                    Id=2,
                    Name="Peppy Paneer",
                    Size="Small",
                    Description="Chunky paneer with crisp capsicum and spicy red pepper - quite a mouthful!",
                    Price=150,
                    ImageUrl="002.jpg"
                },
                new PizzaModel{
                    Id=3,
                    Name="Veggie Paradise",
                    Size="Medium",
                    Description="Goldern Corn, Black Olives, Capsicum & Red Paprika",
                    Price=300,
                    ImageUrl="003.jpg"
                },
                new PizzaModel{
                    Id=4,
                    Name="Mexican Green Wave",
                    Size="Large",
                    Description="A pizza loaded with crunchy onions, crisp capsicum, juicy tomatoes and jalapeno with a liberal sprinkling of exotic Mexican herbs.",
                    Price=450,
                    ImageUrl="004.jpg"
                },
                new PizzaModel{
                    Id=5,
                    Name="Indi Tandoori Paneer",
                    Size="Large",
                    Description="It is hot. It is spicy. It is oh-so-Indian. Tandoori paneer with capsicum and red paprika and mint mayo",
                    Price=400,
                    ImageUrl="005.jpg"
                },
                new PizzaModel{
                    Id=6,
                    Name="Cheese N Corn",
                    Size="Small",
                    Description="Cheese And Golden Corn",
                    Price=175,
                    ImageUrl="006.jpg"
                }
            };
        }
        public List<PizzaModel> GetAllPizzas()
        {
            return pizzas;
        }
        public PizzaModel GetPizzaById(int id)
        {
            return pizzas.Find(x => x.Id == id);
        }
        public string GetPizzaByName(int id)
        {
            var pizza = pizzas.Find(x => x.Id == id);
            return pizza.Name;
        }
    }
}
