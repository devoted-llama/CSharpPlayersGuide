
Potion potion = new Potion(PotionType.water);
bool? complete = null;
do {
    Console.WriteLine($"You currently have a {potion.Type} potion");
    Console.WriteLine("Here are the current ingredient choices:");
    string choices = string.Join(", ",Enum.GetNames<IngredientType>());
    Console.WriteLine(choices);
    IngredientType? ingredient = null;
    do {
        Console.Write("Choose an ingredient to add: ");

        string? ingredientS = Console.ReadLine();

        ingredient = ingredientS switch {
            "stardust" => IngredientType.stardust,
            "snake venom" => IngredientType.snakeVenom,
            "dragon breath" => IngredientType.dragonBreath,
            "shadow glass" => IngredientType.shadowGlass,
            "eyeshine gem" => IngredientType.eyeshineGem,
            _ => null
        };
        string? chosenIngredient = ingredient != null ? ingredient.ToString() : "an invalid ingredient!";
        Console.WriteLine($"You chose {chosenIngredient}");
    } while(ingredient == null);

    PotionType newPotionType = (potion.Type, ingredient) switch {
        (PotionType.water,IngredientType.stardust) => PotionType.elixir,
        (PotionType.elixir,IngredientType.snakeVenom) => PotionType.poison,
        (PotionType.elixir,IngredientType.dragonBreath) => PotionType.flying,
        (PotionType.elixir,IngredientType.shadowGlass) => PotionType.invisibility,
        (PotionType.elixir,IngredientType.eyeshineGem) => PotionType.nightSight,
        (PotionType.nightSight,IngredientType.shadowGlass) => PotionType.cloudyBrew,
        (PotionType.invisibility,IngredientType.eyeshineGem) => PotionType.cloudyBrew,
        (PotionType.cloudyBrew,IngredientType.stardust) => PotionType.wraith,
        _ => PotionType.ruined
    };

    potion.Type = newPotionType;
    Console.WriteLine($"You now have a {potion.Type} potion.");
    do {
        Console.WriteLine("Complete the potion or continue?");
        string? decision = Console.ReadLine();

        complete = decision switch {
            "complete" => true,
            "continue" => false,
            _ => null
        };
    } while(complete == null);

} while (complete == false);

class Potion {
    public PotionType Type {get;set;}
    public Potion ( PotionType type) {}
} 
enum PotionType { water, elixir, poison, flying, invisibility, nightSight, cloudyBrew, wraith, ruined }
enum IngredientType { stardust, snakeVenom, dragonBreath, shadowGlass, eyeshineGem }

