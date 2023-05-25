using System;
using System.Collections.Generic;
using System.Linq;

class Pokemon
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Power { get; set; }
    public int Position { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Pokemon> pokemons = new List<Pokemon>();
        Dictionary<string, List<Pokemon>> pokemonsByType = new Dictionary<string, List<Pokemon>>();

        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] tokens = input.Split();
            string command = tokens[0];

            if (command == "add")
            {
                string name = tokens[1];
                string type = tokens[2];
                int power = int.Parse(tokens[3]);
                int position = int.Parse(tokens[4]);

                Pokemon pokemon = new Pokemon { Name = name, Type = type, Power = power, Position = position };
                pokemons.Insert(position - 1, pokemon);

                for (int i = position; i < pokemons.Count; i++)
                {
                    pokemons[i].Position++;
                }

                if (!pokemonsByType.ContainsKey(type))
                {
                    pokemonsByType[type] = new List<Pokemon>();
                }
                pokemonsByType[type].Add(pokemon);

                Console.WriteLine($"Added pokemon {name} to position {position}");
            }
            else if (command == "find")
            {
                string type = tokens[1];
                if (!pokemonsByType.ContainsKey(type))
                {
                    Console.WriteLine($"Type {type}: ");
                }
                else
                {
                    List<Pokemon> typePokemons = pokemonsByType[type];
                    typePokemons.Sort((x, y) =>
                    {
                        if (x.Name != y.Name)
                        {
                            return string.Compare(x.Name, y.Name);
                        }
                        else
                        {
                            return y.Power.CompareTo(x.Power);
                        }
                    });
                    typePokemons = typePokemons.GetRange(0, Math.Min(5, typePokemons.Count));

                    Console.Write($"Type {type}: ");
                    Console.WriteLine(string.Join("; ", typePokemons.Select(p => $"{p.Name}({p.Power})")));
                }
            }
            else if (command == "ranklist")
            {
                int start = int.Parse(tokens[1]);
                int end = int.Parse(tokens[2]);

                for (int i = start - 1; i < end; i++)
                {
                    Pokemon pokemon = pokemons[i];
                    Console.Write($"{pokemon.Position}. {pokemon.Name}({pokemon.Power})");
                    if (i!=end-1)
                    {
                        Console.Write("; ");
                    }
                    else
                    {
                        Console.Write(" ");

                    }
                }
                Console.WriteLine();
            }
        }
    }
}
