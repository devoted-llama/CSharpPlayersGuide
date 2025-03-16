using TheAutomaticTreeHarvester;

Tree tree = new();
Announcer announcer = new(tree);
Harvester harvester = new(tree);
while(true) tree.TryGrow();
