using Part4_PizzaApi.Models;

namespace Part4_PizzaApi.Services;

public static class PizzaService
{
    private static readonly List<Pizza> Pizzas =
        new()
        {
            new Pizza
            {
                Id = 1,
                Name = "Classic Italian",
                IsGlutenFree = false
            },

            new Pizza
            {
                Id = 2,
                Name = "Veggie",
                IsGlutenFree = true
            },

            // Additional record required by the assignment
            new Pizza
            {
                Id = 3,
                Name = "Uganda Special",
                IsGlutenFree = false
            }
        };

    private static int nextId = 4;

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? Get(int id) =>
        Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(
            p => p.Id == pizza.Id
        );

        if (index == -1)
        {
            return;
        }

        Pizzas[index] = pizza;
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);

        if (pizza is null)
        {
            return;
        }

        Pizzas.Remove(pizza);
    }
}