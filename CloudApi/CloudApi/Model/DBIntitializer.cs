using CloudApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApi.Model
{
    public class DBInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            //Create the db if not yet exists
            context.Database.EnsureCreated();

            //Are there already books present ?
            if (!context.Animals.Any())
            {
                var family = new Family()
                {
                    Name = "Felidae",
                    Description = "Felidae is a family of mammals in the order Carnivora." +
                    "The Felidae species exhibit the most diverse fur pattern of all terrestrial carnivores." +
                    "Felidae have retractile claws,slender muscular bodies and strong flexible forelimbs.Their teeth and facial muscles allow for a powerful bite.",
                    
                };
                var family2 = new Family()
                {
                    Name = "Elephantidae",
                    Description = "The Elephantidae are a family of large, herbivorous mammals collectively called elephants and mammoths." +
                    " These are terrestrial large mammals with a snout modified into a trunk and teeth modified into tusks." +
                    " Most genera and species in the family are extinct. Only two genera, Loxodonta (African elephants) " +
                    "and Elephas (Asiatic elephants), are living."

                };
                //context.Authors.Add(author);

                var animal = new Animal()
                {
                    Name = "Cat",
                    Family = family,
                    Description = "The cat (Felis catus) is a small carnivorous mammal.  It is the only domesticated species in the family Felidae and " +
                    "often referred to as the domestic cat to distinguish it from wild members of the family. The cat is either a house cat, " +
                    "kept as a pet, or a feral cat, freely ranging and avoiding human contact. A house cat is valued by humans for companionship and " +
                    "for its ability to hunt rodents. About 60 cat breeds are recognized by various cat registries.",
                    LifeSpan = 15.1,
                    ConservationStatus = "Domesticated",
                    ImageURL = "UBVLzjA.jpg",
                    Order = "Carnivora"
                };

                var animal2 = new Animal()
                {
                    Name = "Puma",
                    Family = family,
                    Description = "Pumas are large, secretive cats. They are also commonly known as cougars and mountain lions, " +
                    "and are able to reach larger sizes than some other 'big' cat individuals. Despite their large size, they are thought to " +
                    "be more closely related to smaller feline species. The seven subspecies of pumas all have similar characteristics, but tend to vary " +
                    "in color and size. Pumas are thought to be one of the most adaptable of felines on the American continents, because they are found in a " +
                    "variety of different habitats, unlike other various cat species.",
                    LifeSpan = 10.5,
                    ConservationStatus ="Not Endangered",
                    ImageURL = "NOMmk9s.jpg",
                    Order = "Carnivora"
                };
                var animal3 = new Animal()
                {
                    Name = "Elephant",
                    Family = family2,
                    Description = "Elephants are large mammals of the family Elephantidae in the order Proboscidea. " +
                    "Three species are currently recognised: the African bush elephant (Loxodonta africana), " +
                    "the African forest elephant (L. cyclotis), and the Asian elephant (Elephas maximus). Elephants are " +
                    "scattered throughout sub-Saharan Africa, South Asia, and Southeast Asia. Elephantidae is the only surviving " +
                    "family of the order Proboscidea; other, now extinct, members of the order include deinotheres, gomphotheres, " +
                    "mastodons, anancids and stegodontids; Elephantidae itself also contains several now extinct groups, such as the " +
                    "mammoths and straight-tusked elephants.",
                    LifeSpan = 65,
                    ConservationStatus = "Endangered",
                    ImageURL = "adYfMQA.jpg",
                    Order = "Proboscidea"
                };
                var animal4 = new Animal()
                {
                    Name = "Tiger",
                    Family = family,
                    Description = "The tiger (Panthera tigris) is the largest species among the Felidae and classified in the genus Panthera." +
                    " It is most recognizable for its dark vertical stripes on reddish-orange fur with a lighter underside." +
                    " It is an apex predator, primarily preying on ungulates such as deer and bovids. It is territorial and generally " +
                    "a solitary but social predator, requiring large contiguous areas of habitat, which support its requirements for prey" +
                    " and rearing of its offspring. Tiger cubs stay with their mother for about two years, before they become independent " +
                    "and leave their mother's home range to establish their own.",
                    LifeSpan = 17,
                    ConservationStatus = "Endangered",
                    ImageURL = "u3Miu5U.jpg",
                    Order = "Carnivora"
                };
                var animal5 = new Animal()
                {
                    Name = "Lion",
                    Family = family,
                    Description = "The lion (Panthera leo) is a species in the family Felidae; it is a muscular, deep-chested cat with a short, " +
                    "rounded head, a reduced neck and round ears, and a hairy tuft at the end of its tail. The lion is sexually dimorphic; males " +
                    "are larger than females with a typical weight range of 150 to 250 kg (330 to 550 lb) for males and 120 to 182 kg (265 to 400 lb) " +
                    "for females. Male lions have a prominent mane, which is the most recognisable feature of the species. A lion pride consists of a " +
                    "few adult males, related females and cubs. Groups of female lions typically hunt together, preying mostly on large ungulates. The " +
                    "species is an apex and keystone predator, although they scavenge when opportunities occur. Some lions have been known to hunt " +
                    "humans, although the species typically does not.",
                    LifeSpan = 12,
                    ConservationStatus = "Vulnerable",
                    ImageURL = "eAP3wll.jpg",
                    Order = "Carnivora"
                };
                var animal6 = new Animal()
                {
                    Name = "Leopard",
                    Family = family,
                    Description = "The leopard (Panthera pardus) is one of the five extant species in the genus Panthera, " +
                    "a member of the Felidae. It occurs in a wide range in sub-Saharan Africa, in small parts of Western " +
                    "and Central Asia, on the Indian subcontinent to Southeast and East Asia. It is listed as Vulnerable on " +
                    "the IUCN Red List because leopard populations are threatened by habitat loss and fragmentation, and are " +
                    "declining in large parts of the global range. In Hong Kong, Singapore, Kuwait, Syria, Libya, Tunisia and " +
                    "most likely in Morocco, leopard populations have already been extirpated.Contemporary records suggest " +
                    "that the leopard occurs in only 25% of its historical global range. Leopards are hunted illegally, " +
                    "and their body parts are smuggled in the wildlife trade for medicinal practices and decoration.",
                    LifeSpan = 15.5,
                    ConservationStatus = "Vulnerable",
                    ImageURL = "rWfQT43.jpg",
                    Order = "Carnivora"
                };
                var animal7 = new Animal()
                {
                    Name = "Cheetah",
                    Family = family,
                    Description = "The cheetah is a large cat of the subfamily Felinae that occurs in North," +
                    " Southern and East Africa, and a few localities in Iran. It inhabits a variety of mostly arid habitats like dry forests," +
                    " scrub forests, and savannahs. The species is IUCN Red Listed as Vulnerable, as it suffered a substantial decline in its " +
                    "historic range in the 20th century due to habitat loss, poaching for the illegal pet trade, and conflict with humans. By 2016, " +
                    "the global cheetah population has been estimated at approximately 7,100 individuals in the wild. Several African countries have" +
                    " taken steps to improve cheetah conservation measures.",
                    LifeSpan = 14.5,
                    ConservationStatus = "Vulnerable",
                    ImageURL = "GhgBnWM.jpg",
                    Order = "Carnivora"
                };
                var animal8 = new Animal()
                {
                    Name = "Lynx",
                    Family = family,
                    Description = "A lynx is any of the four species (Canada lynx, Iberian lynx, Eurasian lynx, bobcat) within the " +
                    "medium-sized wild cat genus Lynx. The name lynx originated in Middle English via Latin from the Greek word λύγξ, derived " +
                    "from the Indo-European root leuk- ('light, brightness') in reference to the luminescence of its reflective eyes. " +
                    "Two other cats that are sometimes called lynxes, the caracal(desert lynx) and the jungle cat(jungle lynx), are not " +
                    "members of the genus Lynx.",
                    LifeSpan = 7,
                    ConservationStatus = "Not Endangered",
                    ImageURL = "09Nc4Vk.jpg",
                    Order = "Carnivora"
                };
                context.Animals.Add(animal);
                context.Animals.Add(animal2);
                context.Animals.Add(animal3);
                context.Animals.Add(animal4);
                context.Animals.Add(animal5);
                context.Animals.Add(animal6);
                context.Animals.Add(animal7);
                context.Animals.Add(animal8);
                context.Families.Add(family);
                context.Families.Add(family2);
                context.SaveChanges();
            }
        }
    }
}
