namespace TrabalhoFinalBackEnd.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Trabalho_Final.Models;
    using TrabalhoFinalBackEnd.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TrabalhoFinalBackEnd.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TrabalhoFinalBackEnd.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //*********************************************************************
            // adiciona Filmes
           var filmes = new List<Filmes> {
                 new Filmes {IdFilme=1, Nome="Avengers: Infinity War", DataLancamento=new DateTime(2018,4,25), Realizador="Anthony Russo",Companhia="Marvel", Duracao=149,Resumo="The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.",  Trailer="6ZfuNTqbHE8", Cartaz="img_cartaz_1.jpg"},
                 new Filmes {IdFilme=2, Nome="Deadpool", DataLancamento=new DateTime(2016,2,11), Realizador="Tim Miller",Companhia="Marvel", Duracao=108,Resumo="A fast-talking mercenary with a morbid sense of humor is subjected to a rogue experiment that leaves him with accelerated healing powers and a quest for revenge." , Trailer="Xithigfg7dA", Cartaz="img_cartaz_2.jpg"},
                 new Filmes {IdFilme=3, Nome="The Shape of Water", DataLancamento=new DateTime(2018,2,1), Realizador="Guillermo del Toro",Companhia="Fox Searchlight Pictures", Duracao=123,Resumo="A fast-talking mercenary with a morbid sense of humor is subjected to a rogue experiment that leaves him with accelerated healing powers and a quest for revenge." , Trailer="XFYWazblaUA", Cartaz="img_cartaz_3.jpg"},
                 new Filmes {IdFilme=4, Nome="CHIPS", DataLancamento=new DateTime(2017,3,23), Realizador="Dax Shepard",Companhia="Warner Bros.", Duracao=100, Resumo="A rookie officer is teamed with a hardened pro at the California Highway Patrol, though the newbie soon learns his partner is really an undercover Fed investigating a heist that may involve some crooked cops.", Trailer="0IfqqUTW-i4", Cartaz="img_cartaz_4.jpg"},
                 new Filmes {IdFilme=5, Nome="Passengers", DataLancamento=new DateTime(2016,12,22), Realizador="Morten Tyldum", Companhia="Sony Pictures Entertainment", Duracao=116, Resumo="A spacecraft traveling to a distant colony planet and transporting thousands of people has a malfunction in its sleep chambers. As a result, two passengers are awakened 90 years early.", Trailer="7BWWWQzTpNU", Cartaz="img_cartaz_5.jpg"}
            };
            filmes.ForEach(ff => context.Filmes.AddOrUpdate(f => f.IdFilme, ff));
            context.SaveChanges();

            //*********************************************************************
            // adiciona Utilizadores
            var utilizadores = new List<Utilizadores> {
                    new Utilizadores {ID=1,UserName="util1@mail.pt"},
                    new Utilizadores {ID=2,UserName="util2@mail.pt"},
                    new Utilizadores {ID=3,UserName="util3@mail.pt"},
                    new Utilizadores {ID=4,UserName="util4@mail.pt"},
                    new Utilizadores {ID=5,UserName="util5@mail.pt"},
                };
            utilizadores.ForEach(oo => context.Utilizadores.AddOrUpdate(o => o.ID, oo));
            context.SaveChanges();

            //*********************************************************************
            // adiciona Filmes
            var reviews = new List<Reviews> {
                new Reviews {IdReview=1, TituloReview="The amount of people that don't understand the movie is astonishing",
                   Review ="All the reviews that say this movie has no plot are either trolls, idiots, or didn't are to take the time to watch previous marvel movies. Every single one of those ratings and reviews should be taken down and not added to the rating for Infinity War because of their fundamental lack of understanding. It's like coming in and watching the last 2 minutes of an hour long drama show and saying this episode sucks because it has no plot. It's utterly ridiculous! \n There have been 31 marvel movies leading up to this point. All 31 has have some plot that leads to infinity war. Infinity War IS the end game movie. There is nothing left to explain, nothing left to discuss, it is all-out fight for control of the most powerful items in existence, the infinity stones.There have been 31 movies to explain in someway the power of these stones and / or the heroes that come together to fight Thanos in this movie.It's like a long game of chess where Thanos finally makes his move, and it's a huge one. \nSo I beg of any of you who reads this.Don't listen to anyone who says this movie has no plot, has no reason and is only fighting. They aren't worth listening to, Infinity Wars has roughly 60 hours of plot from 31 precious movies leading up to this monumental fight for life or death, and the movie is done to near perfection.The movie is glorious, the CGI is fantastic, the battles are awe - inspiring, and Thanos is made worth of your fear from the very beginning.He is truly the Mad Titan that captures your heart and crushes it right in front of your eyes.Anyone who doesn't think this clearly didn't see the same movie.",
                    NStars =10, Data=new DateTime(2018,4,27), FilmeFK=1, UtilizadorFK=1},
                new Reviews {IdReview=2, TituloReview="Too many characters, prolonged action scenes become monotonous",NStars =2,
                    Review ="The plot follows Thanos around on his quest to collect 5 stones, achieve control of all dimensions and eliminate half of humanity in an attempt to save planets from population induced ecosystem destruction/annihilation. Each stone quest involves 10 minutes or so of the same CGI fighting. Why 5 stones? Why not, they've got time to fill. Lots and lots of time. Many of the characters are likeable esp the Guardians of the Galaxy, the Hulk and Tony Stark BUT, there are just too many groups involved with too much repetition. The plot is mildly interesting daring to touch on overpopulation crisis. Thanos makes a good point. Though in true Hollywood style, he goes about it the wrong way. He should have sterilized half the planet, not dissolve them.",
                    Data=new DateTime(2018,5,2), FilmeFK=1, UtilizadorFK=2},
                new Reviews {IdReview=3, TituloReview="All in",
                    Review ="MAJOR SPOILERS!! DO NOT READ IF YOU HAVEN'T SEEN THE FILM! My headline is the easy way to describe this movie. It is grand, majestic and spectacular. Just like Thanos towering everyone else with his physique this movie also stands above everything else, at least most of it. Because wow, this movie is really something to behold. Marvel went all in with everything here, the cgi is phenomenal, the acting is great, the story is well told, the pacing is near perfect. I have seen this movie twice in IMAX 3D and once in 4DX now, and i have never seen a movie with better image quality than this one, never." +
                    "Ever since the MCU started with Iron Man i have seen every film released, most of them are good, some are outright great, a few are mediocre and very few are bad. But for the most part it has been a hell of a ride, and I've eagerly been awaiting this movie for quite some time, we all knew that it would come down to this, but were you prepared for what would be the outcome? Not many were, though many of us knew several avengers and other major characters would die in this film, i did not expect it to be this many. \n \n This movie truly didn't waste any time getting down to business, as before ten minutes had passed, Heimdall and Loki are killed, and we see the Titan kick the crap out of Hulk, this set the tone for the entire movie right of the bat, and was IMO a smart move, now we knew for sure what a badass Thanos is, and this was before he got all the stones. " +
                    "What the Russo brothers have done here is to overdo themselves.Winter Soldier and Civil War are two of the best MCU movies to date, and you got to wonder how Marvel found these guys, and knew what they were capable of, because Infinity War just lifted the bar even higher.This movie is sort of Michael Bay's wet dream, this is what he wants to achieve, but never can because he has no idea how to tell a story or handle emotions. This movie is a 2 hour and 30 minute spectacle, which has action scene after action scene lined up, and it never feels too much, somehow they managed to balance it, and that is a feat not many directors can pull off. " +
                    "But also the music is masterfully composed, and fit every scene perfectly.And the costumes and props design are state of the art, everything looks and feels so right in this film, all the people involved has done an outstanding job. " +
                    "And i really have to give it to Josh Brolin.Thanos is easily the best villain i have seen in quite some time.He is a complex villain, that is so well portrayed i almost start rooting for him, and that is saying something come to think how many years i have grown to love the avengers and the guardians.This is also big thanks to the amazing cgi that just brings so much life into the character.I can understand his motivations, i can side with his thoughts, i both agree and i disagree at same time.Such a great character, easily the best MCU villain so far, and i had Loki as my favorite before him. " +
                    "At the end when Spider - man, Doctor Strange, Scarlett Witch, Nick Fury, Star - Lord, Black Panther, Mantis, Bucky Barnes and many others are killed because he gets all the stones, i both felt a sense of pride for Thanos completing his mission, he truly is a determined badass.But at the same time i felt great sadness that so many of the characters that i loved, are dead. \n \n " +
                    "But MCU has killed characters before, which has been brought back to life, so i guess that will be the case here as well, as the next movie most likely will deal with time travel and fight Thanos in the future and the past.Dr.Strange gave up the time stone because of the 14.000.605 outcomes that he saw, only one lead to victory for the avengers, and giving up the stone was the beginning of the victory path.So even though this movie ended on a cliffhanger, it left enough hints that will be talked about for a whole year, and it will build the biggest hype in the history of cinema.So at the end of the day, this movie just delivers on so many levels, and it will make way for the rise of many new characters to enter the MCU, and finally take down Thanos and undo some of the damage he has done. " +
                    "It's quite amazing that this movie actually managed to live up to the hype, that should not even be possible when you think about it, but it did. The movie is absolutely amazing. " +
                    "I can't wait for Avengers 4.",
                    NStars =9, Data=new DateTime(2018,4,25), FilmeFK=1, UtilizadorFK=3},
                new Reviews {IdReview=4, TituloReview="Near-flawless action/space epic",Review="SPOILER: 'Avengers: Infinity War' is the third Avengers film and the 19th Marvel Cinematic Universe film overall, serving as a culmination of the last 10 years. Will not a full-stop (Avengers 4 comes out next year), it does a great job of bringing the much-teased infinity stones/Thanos storyline together. Lots of knowledge of the previous MCU films is assumed, especially the two most recent films which lead directly in to this film - 'Thor: Ragnarok' and 'Black Panther'. It might make some sense if you haven't seen the others, but probably not too much. " +
                "The stakes are certainly high, with a number of deaths of key characters throughout (no spoilers) and the opening scene literally taking no prisoners. The vital part of this film is the villain, Thanos (Brolin) who - despite being large, ugly & purple - gets enough backstory and shows adequate ethos to almost empathise with his reasoning for wanting to destroy half the universe(via the infinity stones).While there's some deaths and plenty of tension/darkness in parts, there's still lots of laughs, mostly thanks to Thor(Hemsworth), Starlord(Pratt), Rocket(Cooper) and Drax(Bautista). " +
                "The CGI is fantastic the entire film, with plenty of scenes in space and on new planets, which is always great to see - as is Iron Man (Downey Jr.) 's inevitable new suit. The way the team-ups are handled is done really well, with Dr Strange (Cumberbatch), the Guardians of the Galaxy, Spider-Man (Holland), Black Panther (Boseman) and the Avengers all split up, so there's always different scenes moving things along at a good pace.The third act battle is not predictable and the ending is hugely shocking - certainly no cop-out. ",
                    NStars =9, Data=new DateTime(2018,4,25), FilmeFK=1, UtilizadorFK=4},
                new Reviews {IdReview=5, TituloReview="ABOVE MY EXPECTATION.",Review="Just WOW , The Russo nailed it, hand down from me they did it again. Part by part is interesting to watch , some of scene make me shock some scene make me wanna punch people so bad. Thanos is the best villain I've ever seen. He not just normal villain to kill bunch of people because he love but his motivation so clear why he wanna do that and most people know he is collecting all the infinity stones. " +
                "One of the best part of it the team up Guardian & Avengers just amazing, full of humor cannot stop laughing watching their scene together. For 1st time my brain cannot process what going to happen in Avengers 4 really hype about it. " +
                "Really worth watching it , if u non Marvel fans or superheroes fan this movie is worth to watch , really enjoy it.Of course every good movie always have some issue with it but just MINOR issue can close eye and let it go. Going to watch it again soon . Love from Malaysia.",
                    NStars =10, Data=new DateTime(2018,4,26), FilmeFK=1, UtilizadorFK=5},
                new Reviews {IdReview=6, TituloReview="This is what it looks like when filmmakers take risks",
                    Review ="Deadpool is a triumph of artistic vision over studio interference. Little credit should be given to 20th Century Fox, as they had zero faith in the success of a Deadpool movie. To put things into perspective, Ryan Reynolds fought for this film back in 2004 when Blade: Trinity was released. Reynolds and co. went to shoot test footage that was then leaked online by Reynolds because Fox had no intentions to release it to the public. Finally, after years and years of BEGGING to the studio and the overwhelming positive responses of the test footage from the public, Fox didn't even tell Reynolds and co. that the film was greenlit. They had to find out online like the rest of us plebeians. If that sounds bad, Fox even cut their budget by $7 million AT THE LAST MINUTE, which caused the writers to scratch some action sequences that I'm sure would've been great to see. " +
                    "Deadpool now has the biggest opening weekend in the month of February (surpassing Fifty Shades of Grey), the biggest opening weekend for 20th Century Fox(surpassing all the X - Men films), and the biggest opening weekend for an R rated film EVER(surpassing The Matrix: Reloaded).With all that being said, Deadpool is a hilariously entertaining film that works mainly because of Reynolds himself.His comedic skills pay off gloriously as the titular character, who gives so many quips in one instance that some jokes will be missed.Of course, credit should be given to the writers too(AKA: The Real Heroes Here), and it's impressive that this is Tim Miller's directorial debut.The action sequences and pacing are so good that you'd think this came from a veteran director. " +
                    " From the ingenious opening credits to the subversive ending, Deadpool constantly upends clichés and tropes you're used to seeing in superhero flicks in the past few years. What's great here is the filmmakers had something weird and perverse and just went with it.Jokes about pedophilia, pegging, and sex run rampant, but it's never really dark, despite the mature subject matter. On top of that, it's also very refreshing to see a pansexual superhero in such a big studio film.It's unheard of these days. Fox and other studios, learn from this success. It's not the fact that a hard R - rated film can do well, it's that Deadpool also happens to be very good, most likely because you, Fox, actually gave the filmmakers the creative freedom to do whatever the hell they wanted.",
                    NStars =8, Data=new DateTime(2016,2,15), FilmeFK=2, UtilizadorFK=1},
                new Reviews {IdReview=6, TituloReview="Best Movie I Have Seen In A Long Time",
                    Review ="Firstly I would like to state that it is completely hilarious reading reviews with One Star because the movie had \"Foul Language\" and \"Sex Scenes\" or that someone had no idea that the movie was inappropriate for their 9 year old kid. Dead Pool is rated R and with 3 minutes of research you could have determined if this movie was for you or not With that being said I will not delve into the plot but the acting and writing were fantastic. Ryan Reynolds nailed this role. If you are easily offended by violence, language, or nudity this is not the movie for you but if you have a sense of humor and want to be entertained for 2 straight hours you will love this movie.",
                    NStars =10, Data=new DateTime(2016,2,17), FilmeFK=2, UtilizadorFK=2},
                new Reviews {IdReview=7, TituloReview="a much needed breath of fresh air in a stale genre",
                    Review ="At first glance, Deadpool seems like a typical superhero movie due to it being made by Marvel. But once those hilarious intro credits show up, you know you are in for one of the most creative films in recent years. " +
                    "The first thing that is unique about this film is the characters. In typical superhero films the characters are stiff and super serious, in Deadpool the characters are filled with personality and can range from the serious Francis to the silly Deadpool giving this a parody like feel, in a good way. " +
                    "Also what is different is that this is a story of revenge rather then saving the city/world/universe that is seen in every single superhero film. Also the tone of film is more comic then dark thanks to the fantastic humor of all kinds from slapstick to dirty to just plain silly, this film just does not stop the laughs (I laughed 20- 30 times in my SECOND watch). " +
                    "As for being an origin story, I can say that the backstory placements were well done, equally as funny, and explains only what is important in understanding the story.Final rating 10 / 10 this is a great nominee for movie of the year and one of the greatest comedies ever made",
                    NStars =9, Data=new DateTime(2016,9,26), FilmeFK=2, UtilizadorFK=3},
                new Reviews {IdReview=8, TituloReview="Funny, entertaining and refreshing",
                    Review ="I am aware that to many people (especially those unfamiliar with Deadpool comic or Marvel comics at all) this movie would seem too gory, unnecessary brutal and excessively violent. But this movie is a comedy, where its main protagonist, Deadpool, should be perceived as a comedian, and Ryan Reynolds did an excellent job representing this character. " +
                    "The story of Deadpool isn't complex or profound - and it wasn't meant to be. This movie is all about fun and entertainment, abundant with action, jokes, blood and foul language. Therefore, it is not suitable for children.I grew tired of people thinking that movies based on comics are intended for children only. " +
                    "Related to that, I believe that many Marvel movies could have been far more successful if they didn't refrain from gory scenes. I am sorry, but if you want to make a serious combat-based movie and you make it without blood, than that movie will be all but serious. " +
                    "That is why I see Deadpool as a refreshment.Nowadays many writers and directors are too worried about political correctness in their movies. That really stifles creativity and that is why today we have so many movies with great ideas but poor realization. " +
                    "Thus, to me, Deadpool was a very pleasant surprise, I had fun watching it, and I intend to watch it again some time soon.",
                    NStars =8, Data=new DateTime(2016,10,18), FilmeFK=2, UtilizadorFK=4},
                new Reviews {IdReview=9, TituloReview="Self-congratulatory and Gratuitous Despite Technical Triumph",
                    Review ="Del Toro's gift for effective story-telling cannot be denied. However, the film plays perfectly into mainstream Hollywood sensibilities, does not have a profound artistic vision, and fails to challenge the audience in any meaningful way. It has the quintessential villain in the liberal cultural imagination today - a racist, sexist, ableist, psychopathic white man in the 60s. He lives in a bourgeois suburban neighborhood and has the quintessential white nuclear family. The fact that he is made to exhibit psychopathic behaviors is of course a way to obscure the irreducibly cultural, structural, and political conditions that the film purports to problematize. The equally cut-and-dry story is about people living at the margins of society bonding over their mutually subjugated status. The self-congratulatory moralistic undertone of this film suspends any need for serious cultural reflection. Shown to conservatives, the film is unlikely to have any converts to progressive politics. Shown to liberals, it will only confirm their pre-established identitarian convictions. Sprinkled with some gratuitous violence, it is the perfect candidate for the Oscars - a polished, glib, pandering, ostensibly radical fairy tale that ultimately does not have any enduring contribution to an already mediocre culture.",
                    NStars =6, Data=new DateTime(2018,2,4), FilmeFK=3, UtilizadorFK=1},
                new Reviews {IdReview=10, TituloReview="Really boring!",
                    Review ="I don't find anything interesting in this movie. I know that most people love it but does it deserve 13 Oscar nominations? At least they only won 4. And the end is the most dissapointing part. Can anyone say that I'm wrong?",
                    NStars =1, Data=new DateTime(2018,3,22), FilmeFK=3, UtilizadorFK=2},
                new Reviews {IdReview=11, TituloReview="If you have a taste for the unusual, I highly recommend The Shape of Water",
                    Review ="When my movie theatre-working friend said this was weird, I said it was also beautiful to which he said \"Huh?\" though he also said to a co-worker he also liked it. Kudos to the director, writers, and all the cast for this fine film about a mute woman who feels something for a creature brought to the lab building she works for as a domestic. So on that note, if you have a taste for the unusual, I highly recommend The Shape of Water.",
                    NStars =10, Data=new DateTime(2018,2,1), FilmeFK=3, UtilizadorFK=3},
                new Reviews {IdReview=12, TituloReview="Entertaining comedy",
                    Review ="All too often people like to rag on movies like this. Not every movie to hit the cinema will be Oscar worthy, Not every movie will be written with a story that will move you to tears or challenge your thinking. Set your expectations for the movie you will see and you are less likely to be disappointed." +
                    "Chips is an entertaining cop buddy flick, rated R and has some adult humor. Both Pena and Shepard play their parts well and along the way the movie pokes fun at itself and the genre. There are plenty of laughs to be had here and overall the movie went at a steady pace. There is nothing ground breaking in it but I wanted a laugh, I got a laugh. Hopefully it does well enough at the box office to get a sequel.",
                    NStars =7, Data=new DateTime(2017,3,29), FilmeFK=4, UtilizadorFK=1},
                new Reviews {IdReview=13, TituloReview="People are being too harsh, very funny film!!",
                    Review ="As a preface, I have never seen an episode of the original show; I knew Estrada was in it and that's all. So, if you're a fan of the series, I cannot say whether you will enjoy this film (though based on other reviews I've read, it seems unlikely). " +
                    "What I can tell you is that I had low expectations and just wanted a laugh. Dax Sheppard's films have always been hit-or-miss for me. When I bought the tickets, I wasn't even aware that it was rated R. " +
                    "I was very pleasantly surprised! My friend and I both laughed non-stop at the off-the-wall humor. The success of the jokes was in the delivery - often very deadpan and unexpected. Some reviewers complained about the sex addiction/masturbation jokes, but I found them hilarious due to Sheppard's sincere concern and Peña's awkward embarrassment. " +
                    "As a motorcyclist, I very much enjoyed all the bike action and liked that they kept it relatively realistic (but don't look for realism as a general rule; that's not what comedy is about) regarding the necessary skills (Ponche thought he could match Baker and was sorely mistaken) and the comparative speed of a lightweight sport bike vs. the clunky cruisers. I also loved that, when they upgraded to sport bikes themselves, they wore proper full-body riding gear instead of promoting riding in street clothes as most films do. " +
                    "In short: this is a riot, not an Oscar - winner.Go for laughs, not for a serious cop film.",
                    NStars =9, Data=new DateTime(2017,4,2), FilmeFK=4, UtilizadorFK=2},
                new Reviews {IdReview=14, TituloReview="Stupid",
                    Review ="If I could give this negative stars, I would! This has to be one of the dumbest movies of all time and CHIPS was an awesome television show. " +
                    "I should have know that this would be nothing like the show given the fact that Dax wrote and directed it. Barf-o-rama! I wish these comedians would stop attempting to remake television shows that were awesome back in the day and turning them into a crap fest.",
                    NStars =3, Data=new DateTime(2017,6,1), FilmeFK=4, UtilizadorFK=3},
                new Reviews {IdReview=15, TituloReview="good light fun",
                    Review ="Being one of my favorite TV shows from my child hood I was dreading this remake, but if you let go of the past you will enjoy this movie for what it is and its just light fun with some really funny moments. " +
                    "Plot wise its pretty predictable but is was not 2 hours of my life wasted and in the end I enjoyed the new CHIPS. " +
                    "Ignore the critic wannabe's and give it a go, just don't expect anything from the 80's or that will make you think.",
                    NStars =7, Data=new DateTime(2017,4,24), FilmeFK=4, UtilizadorFK=4},
                new Reviews {IdReview=16, TituloReview="A decent sci-fi rental that plays it too safe.",
                    Review ="I'm just going to list my takeaways from the movie in list format. Maybe it will be helpful to someone, maybe not. " +
                    "Pros - The production is immaculate. The cinematography, set design, CGI, all of it is top notch, as expected from a movie starring two of the most popular current actors. - Although I'm not crazy about Jennifer Lawrence, and I only really like Chris Pratt as Starlord, I will go ahead and list them as a pro, since they did a good job with these characters. Michael Sheen is also welcome in any movie. " +
                    "Cons - The science of the movie is a bit slinky at times, obviously to serve narrative motives. Other reviewers have detailed these inaccuracies, so I won't get into it, here. - The movie mostly leans toward a romantic drama vibe, and I personally think there should have been more of a sense of dread and danger throughout the movie, not just near the end. - Given the high profile status of the leads, the sex scenes are predictably tame and brief. Along with the lack of danger, the lack of eroticism is another way in which the movie plays it too safe. - The catharsis at the end that stems from the main moral dilemma (which I won't spoil) does not occur satisfactorily in my opinion. It didn't move me at all, and made it feel like it was never that important to begin with. " +
                    "In summary, this is an entertaining, but light sci - fi romance.It feels like a 70's sci-thriller that has been thoroughly processed for a general audience. It makes a good rental, but I couldn't help but lament that it wasn't the riskier, edgier film that it wanted to be.",
                    NStars =6, Data=new DateTime(2017,4,7), FilmeFK=5, UtilizadorFK=1},
                new Reviews {IdReview=17, TituloReview="Haunting and beautiful",
                    Review ="I have to admit that I had low expectations when I was going to see this movie. The negative reviews are why. Appearance that the film has gone bad, not earned enough, etc. But it does not make sense to listen to others. The best part is to find out yourself. And I have to admit that I enjoyed this movie well, even though I understand some of the criticisms. At the same time, I know that Morten Tyldum is an incredibly good director. One of the best Norwegian directors, without a doubt. I think it's strange that he made something directly bad. The film is not a featured sci fi movie, even if the action takes place on a spaceship. I enjoyed the movie for three reasons: 1) The story is unique, and something I've never seen before. It's always a good sign. 2) It's beautiful to watch, great movie, spectacular setups and scenes. It was impressive and 3) This movie works to switch between a love story and some action sequences. It seems like a thoughtful movie, and I appreciated the thought behind scenes and action. The few people we meet in the film give insight and one becomes familiar with the characters. It is also a strength, but perhaps also a weakness. The gallery is limited. But anyway, I recommend this and hope to see similar movies in the future.",
                    NStars =8, Data=new DateTime(2017,5,16), FilmeFK=5, UtilizadorFK=2},
                new Reviews {IdReview=18, TituloReview="Definition of Script Problems",
                    Review ="In all science fiction, suspension of disbelief is required to become engaged in the story. However, what the writers of Passengers fail to realize is that suspension of disbelief applies to technology, not human stupidity. The audience can overlook warp drive, ray guns, transporters, etc., but what can't be overlooked is a total lack of common sense in using this technology. There were many opportunities for interesting story lines, but Passengers attempts to patch plot holes that don't work instead of exploring concepts that do. " +
                    "The story centers around a star ship with 5000 passengers and over 200 crew members placed in hibernation for a 120 year trip to another star system to colonize another planet.This part of the story is plausible and even thought provoking.Even the ship itself is based on realistic designs.The science behind this background is sound.The ship is traveling at half the speed of light to a star system 60 light years away for a 120 year trip.Passengers are placed in hibernation to make the trip.So far all of this works and is interesting, but this is about a 5 minute background setting.After that things fall apart.Two passengers are accidentally awoken 90 years too early and face death from old age out in the void of space before reaching a destination.To make this plot work, the unbelievable is required.First, no one is watching the ship, not even automation.If this was a real ship, when an anomaly is detected the crew would be awoken to take care of the problem and put back into hibernation even if they do not take shifts over the century long trip. Second, there is no way to get a person back into hibernation in any way whatsoever.On a trip like this, that disbelief cannot be suspended, because it is too absurd to imagine. There are other things about this story that cannot be disbelieved, but the ones I have mentioned make this plot fall apart." +
                    "One aspect that is interesting, but not properly explored is the reference to The Shining that dominates the movie.When this reference is first introduced the parallels to the insanity that develops from isolation or even possibly a haunted ship were obvious and the prospect exciting.However, the movie does not explore this and the reference is relegated to a running joke.Unfortunate. " +
                    "The setup of the plot has so many possibilities, but you will end this movie realizing that it is a classic example of a problem script that piles on the increasingly absurd and unbelievable in an attempt to cover the holes.",
                    NStars =4, Data=new DateTime(2017,4,10), FilmeFK=5, UtilizadorFK=3},
                new Reviews {IdReview=19, TituloReview="\"Passengers\" offers more than the reviews are giving credit!",
                    Review ="I read many of the reviews too, and while I always say that every movie will treat everyone in a different way, I am a little surprised by the amount of people who didn't enjoy it! I thought this movie was beautiful! " +
                    "If you want a movie with conflict, space exploration, romance, and sci-fi...this movie is for you.While it's not loaded with 'blow em up' action, the movie is filled with tension and does have some great action scenes. The best aspect of the movie (to me) is that the filmmakers were very successful at turning a situation so incredible into something simple and human. " +
                    "I walked away from this movie not wanting it to end.Screw the bad reviews, see it for yourself and maybe you'll see what I saw!",
                    NStars =9, Data=new DateTime(2017,12,23), FilmeFK=5, UtilizadorFK=4},
                new Reviews {IdReview=20, TituloReview="Good ideas, Bad scenario",
                    Review ="I had really great expectations for this movie, and maybe that's the reason why I was so disappointed. Of course, all the actors are great, and even though the direction is not bad, it's really a typical love movie scenario, with the doubt at the beginning, the intense love, the betrayal, and finally the traditional happy ending. That could've been good without all the inconsistencies there are. For example, why didn't they thought to resurrect the captain, just as Aurora did for Jim? And there was enough place for both of them in the end. It would be Titanic all over again if Rose had decided to stay in the water with Jack. Not a bad movie, some ideas are great : leaving a man alone with his thoughts and robots to see his attitude evolve is interesting, the fact that he sacrificed a life instead of staying alone too, but those ideas could've been pushed so much further if they did not decided to focus on their love story. Honorable mention to Arthur, the best character in my opinion.",
                    NStars =5, Data=new DateTime(2017,2,26), FilmeFK=5, UtilizadorFK=5}
            };
            reviews.ForEach(rr => context.Reviews.AddOrUpdate(r => r.IdReview, rr));
            context.SaveChanges();
              
            var categorias = new List<Categorias> {
                new Categorias {IdCategoria=1,Nome="Action", ListaFilmes=new List<Filmes>{ filmes[0], filmes[1], filmes[3] } },
                new Categorias {IdCategoria=2,Nome="Adventure", ListaFilmes=new List<Filmes>{ filmes[0], filmes[1], filmes[2] } },
                new Categorias {IdCategoria=3,Nome="Comedy", ListaFilmes=new List<Filmes>{ filmes[1], filmes[3] } },
                new Categorias {IdCategoria=4,Nome="Crime", ListaFilmes=new List<Filmes>{ filmes[3] } },
                new Categorias {IdCategoria=5,Nome="Crossover", ListaFilmes=new List<Filmes>{ } },
                new Categorias {IdCategoria=6,Nome="Drama", ListaFilmes=new List<Filmes>{ filmes[2], filmes[4] } },
                new Categorias {IdCategoria=7,Nome="Fantasy", ListaFilmes=new List<Filmes>{ filmes[0], filmes[2] } },
                new Categorias {IdCategoria=8,Nome="Horror", ListaFilmes=new List<Filmes>{ } },
                new Categorias {IdCategoria=9,Nome="Musical", ListaFilmes=new List<Filmes>{ } },
                new Categorias {IdCategoria=10,Nome="Philosophy", ListaFilmes=new List<Filmes>{ } },
                new Categorias {IdCategoria=11,Nome="Polic", ListaFilmes=new List<Filmes>{ } },
                new Categorias {IdCategoria=12,Nome="Religious", ListaFilmes=new List<Filmes>{ } },
                new Categorias {IdCategoria=13,Nome="Road", ListaFilmes=new List<Filmes>{ } },
                new Categorias {IdCategoria=14,Nome="Romance", ListaFilmes=new List<Filmes>{ } },
                new Categorias {IdCategoria=15,Nome="Sci-Fi", ListaFilmes=new List<Filmes>{ filmes[4] } },
                new Categorias {IdCategoria=16,Nome="Sport", ListaFilmes=new List<Filmes>{ } },
                new Categorias {IdCategoria=17,Nome="Spy", ListaFilmes=new List<Filmes>{ } },
                new Categorias {IdCategoria=18,Nome="Thriller", ListaFilmes=new List<Filmes>{ filmes[4] } }
            };
            categorias.ForEach(cc => context.Categorias.AddOrUpdate(c => c.IdCategoria, cc));
            context.SaveChanges();
            
            var imagens = new List<Imagens> {
                new Imagens {IdImg=1,Nome="Img_1.jpg",FilmeFK=1},
                new Imagens {IdImg=2,Nome="Img_2.jpg",FilmeFK=1},
                new Imagens {IdImg=3,Nome="Img_3.jpg",FilmeFK=1},
                new Imagens {IdImg=4,Nome="Img_4.jpg",FilmeFK=2},
                new Imagens {IdImg=5,Nome="Img_5.jpg",FilmeFK=2},
                new Imagens {IdImg=6,Nome="Img_6.jpg",FilmeFK=2},
                new Imagens {IdImg=7,Nome="Img_7.jpg",FilmeFK=3},
                new Imagens {IdImg=8,Nome="Img_8.jpg",FilmeFK=3},
                new Imagens {IdImg=9,Nome="Img_9.jpg",FilmeFK=3},
                new Imagens {IdImg=10,Nome="Img_10.jpg",FilmeFK=4},
                new Imagens {IdImg=11,Nome="Img_11.jpg",FilmeFK=4},
                new Imagens {IdImg=12,Nome="Img_12.jpg",FilmeFK=4},
                new Imagens {IdImg=13,Nome="Img_13.jpg",FilmeFK=5},
                new Imagens {IdImg=14,Nome="Img_14.jpg",FilmeFK=5},
                new Imagens {IdImg=15,Nome="Img_15.jpg",FilmeFK=5}
            };
            imagens.ForEach(ii => context.Imagens.AddOrUpdate(i => i.IdImg, ii));
            context.SaveChanges();
            
            
            var atores = new List<Atores> {
                new Atores {IdAtor=1,Nome="Robert Downey Jr.",DataNascimento=new DateTime(1965,4,4),Imagem="img_ator_1.jpg"},
                new Atores {IdAtor=2,Nome="Chris Hemsworth",DataNascimento=new DateTime(1983,8,11),Imagem="img_ator_2.jpg"},
                new Atores {IdAtor=3,Nome="Mark Ruffalo",DataNascimento=new DateTime(1967,11,22),Imagem="img_ator_3.jpg"},
                new Atores {IdAtor=4,Nome="Chris Evans",DataNascimento=new DateTime(1981,6,13),Imagem="img_ator_4.jpg"},
                new Atores {IdAtor=5,Nome="Scarlett Johansson",DataNascimento=new DateTime(1984,11,22),Imagem="img_ator_5.jpg"},
                new Atores {IdAtor=6,Nome="Don Cheadle",DataNascimento=new DateTime(1964,11,29),Imagem="img_ator_6.jpg"},
                new Atores {IdAtor=7,Nome="Benedict Cumberbatch",DataNascimento=new DateTime(1976,7,19),Imagem="img_ator_7.jpg"},
                new Atores {IdAtor=8,Nome="Tom Holland",DataNascimento=new DateTime(1996,6,1),Imagem="img_ator_8.jpg"},
                new Atores {IdAtor=9,Nome="Chadwick Boseman",DataNascimento=new DateTime(1977,11,29),Imagem="img_ator_9.jpg"},
                new Atores {IdAtor=10,Nome="Zoe Saldana",DataNascimento=new DateTime(1978,6,19),Imagem="img_ator_10.jpg"},
                new Atores {IdAtor=11,Nome="Karen Gillan",DataNascimento=new DateTime(1987,11,28),Imagem="img_ator_11.jpg"},
                new Atores {IdAtor=12,Nome="Tom Hiddleston",DataNascimento=new DateTime(1981,2,9),Imagem="img_ator_12.jpg"},
                new Atores {IdAtor=13,Nome="Paul Bettany",DataNascimento=new DateTime(1971,5,27),Imagem="img_ator_13.jpg"},
                new Atores {IdAtor=14,Nome="Elizabeth Olsen",DataNascimento=new DateTime(1989,2,16),Imagem="img_ator_14.jpg"},
                new Atores {IdAtor=15,Nome="Anthony Mackie",DataNascimento=new DateTime(1978,9,23),Imagem="img_ator_15.jpg"},
                new Atores {IdAtor=16,Nome="Sebastian Stan",DataNascimento=new DateTime(1982,8,13),Imagem="img_ator_16.jpg"},
                new Atores {IdAtor=17,Nome="Idris Elba",DataNascimento=new DateTime(1972,9,6),Imagem="img_ator_17.jpg"},
                new Atores {IdAtor=18,Nome="Danai Gurira",DataNascimento=new DateTime(1978,2,14),Imagem="img_ator_18.jpg"},
                new Atores {IdAtor=19,Nome="Peter Dinklage",DataNascimento=new DateTime(1969,6,11),Imagem="img_ator_19.jpg"},
                new Atores {IdAtor=20,Nome="Benedict Wong",DataNascimento=new DateTime(1971,6,3),Imagem="img_ator_20.jpg"},
                new Atores {IdAtor=21,Nome="Pom Klementieff",DataNascimento=new DateTime(1986,5,3),Imagem="img_ator_21.jpg"},
                new Atores {IdAtor=22,Nome="Dave Bautista",DataNascimento=new DateTime(1969,1,18),Imagem="img_ator_22.jpg"},
                new Atores {IdAtor=23,Nome="Vin Diesel",DataNascimento=new DateTime(1967,6,18),Imagem="img_ator_23.jpg"},
                new Atores {IdAtor=24,Nome="Bradley Cooper",DataNascimento=new DateTime(1975,1,5),Imagem="img_ator_24.jpg"},
                new Atores {IdAtor=25,Nome="Gwyneth Paltrow",DataNascimento=new DateTime(1972,9,27),Imagem="img_ator_25.jpg"},
                new Atores {IdAtor=26,Nome="Josh Brolin",DataNascimento=new DateTime(1968,2,12),Imagem="img_ator_26.jpg"},
                new Atores {IdAtor=27,Nome="Chris Pratt",DataNascimento=new DateTime(1979,6,21),Imagem="img_ator_27.jpg"},
                new Atores {IdAtor=28,Nome="Ryan Reynolds",DataNascimento=new DateTime(1976,10,23),Imagem="img_ator_28.jpg"},
                new Atores {IdAtor=29,Nome="Karan Soni",DataNascimento=new DateTime(1989,1,8),Imagem="img_ator_29.jpg"},
                new Atores {IdAtor=30,Nome="Ed Skrein",DataNascimento=new DateTime(1983,3,29),Imagem="img_ator_30.jpg"},
                new Atores {IdAtor=31,Nome="Michael Benyaer",DataNascimento=new DateTime(1970,5,25),Imagem="img_ator_31.jpg"},
                new Atores {IdAtor=32,Nome="Stefan Kapicic",DataNascimento=new DateTime(1978,12,1),Imagem="img_ator_32.jpg"},
                new Atores {IdAtor=33,Nome="Brianna Hildebrand",DataNascimento=new DateTime(1996,8,14),Imagem="img_ator_33.jpg"},
                new Atores {IdAtor=34,Nome="Style Dayne",DataNascimento=new DateTime(1900,1,1),Imagem="img_ator_34.jpg"},
                new Atores {IdAtor=35,Nome="Kyle Cassie",DataNascimento=new DateTime(1976,5,6),Imagem="img_ator_35.jpg"},
                new Atores {IdAtor=36,Nome="Taylor Hickson",DataNascimento=new DateTime(1997,12,11),Imagem="img_ator_36.jpg"},
                new Atores {IdAtor=37,Nome="Randal Reeder",DataNascimento=new DateTime(1971,11,27),Imagem="img_ator_37.jpg"},
                new Atores {IdAtor=38,Nome="T.J. Miller",DataNascimento=new DateTime(1981,6,4),Imagem="img_ator_38.jpg"},
                new Atores {IdAtor=39,Nome="Morena Baccarin",DataNascimento=new DateTime(1979,6,2),Imagem="img_ator_39.jpg"},
                new Atores {IdAtor=40,Nome="Gina Carano",DataNascimento=new DateTime(1982,4,16),Imagem="img_ator_40.jpg"},
                new Atores {IdAtor=41,Nome="Sally Hawkins",DataNascimento=new DateTime(1976,4,27),Imagem="img_ator_41.jpg"},
                new Atores {IdAtor=42,Nome="Michael Shannon",DataNascimento=new DateTime(1974,8,7),Imagem="img_ator_42.jpg"},
                new Atores {IdAtor=43,Nome="Richard Jenkins",DataNascimento=new DateTime(1947,5,4),Imagem="img_ator_43.jpg"},
                new Atores {IdAtor=44,Nome="Octavia Spencer",DataNascimento=new DateTime(1972,5,25),Imagem="img_ator_44.jpg"},
                new Atores {IdAtor=45,Nome="Michael Stuhlbarg",DataNascimento=new DateTime(1968,6,5),Imagem="img_ator_45.jpg"},
                new Atores {IdAtor=46,Nome="Doug Jones",DataNascimento=new DateTime(1960,5,24),Imagem="img_ator_46.jpg"},
                new Atores {IdAtor=47,Nome="David Hewlett",DataNascimento=new DateTime(1968,4,18),Imagem="img_ator_47.jpg"},
                new Atores {IdAtor=48,Nome="Nick Searcy",DataNascimento=new DateTime(1959,3,7),Imagem="img_ator_48.jpg"},
                new Atores {IdAtor=49,Nome="Nigel Bennett",DataNascimento=new DateTime(1949,11,19),Imagem="img_ator_49.jpg"},
                new Atores {IdAtor=50,Nome="Michael Peña",DataNascimento=new DateTime(1976,1,13),Imagem="img_ator_50.jpg"},
                new Atores {IdAtor=51,Nome="Dax Shepard",DataNascimento=new DateTime(1975,1,2),Imagem="img_ator_51.jpg"},
                new Atores {IdAtor=52,Nome="Vincent D'Onofrio",DataNascimento=new DateTime(1959,6,30),Imagem="img_ator_52.jpg"},
                new Atores {IdAtor=53,Nome="Rosa Salazar",DataNascimento=new DateTime(1985,7,16),Imagem="img_ator_53.jpg"},
                new Atores {IdAtor=54,Nome="Jessica McNamee",DataNascimento=new DateTime(1900,1,1),Imagem="img_ator_54.jpg"},
                new Atores {IdAtor=55,Nome="Adam Brody",DataNascimento=new DateTime(1979,12,15),Imagem="img_ator_55.jpg"},
                new Atores {IdAtor=56,Nome="Isiah Whitlock Jr.",DataNascimento=new DateTime(1954,9,13),Imagem="img_ator_56.jpg"},
                new Atores {IdAtor=57,Nome="Jane Kaczmarek",DataNascimento=new DateTime(1955,12,21),Imagem="img_ator_57.jpg"},
                new Atores {IdAtor=58,Nome="Jennifer Lawrence",DataNascimento=new DateTime(1990,8,15),Imagem="img_ator_58.jpg"},
                new Atores {IdAtor=59,Nome="Chris Pratt",DataNascimento=new DateTime(1979,6,21),Imagem="img_ator_59.jpg"},
                new Atores {IdAtor=60,Nome="Michael Sheen",DataNascimento=new DateTime(1969,2,5),Imagem="img_ator_60.jpg"},
                new Atores {IdAtor=61,Nome="Laurence Fishburne",DataNascimento=new DateTime(1961,7,30),Imagem="img_ator_61.jpg"},
                new Atores {IdAtor=62,Nome="Andy Garcia",DataNascimento=new DateTime(1956,4,12),Imagem="img_ator_62.jpg"},
                new Atores {IdAtor=63,Nome="Julee Cerda",DataNascimento=new DateTime(1900,1,1),Imagem="img_ator_63.jpg"}

            };
            atores.ForEach(aa => context.Atores.AddOrUpdate(a => a.IdAtor, aa));
            context.SaveChanges();
            
            var personagens = new List<Personagens> {
                new Personagens {IdPersonagem=1,Nome="Iron Man",Imagem="img_pers_1.jpg",FilmeFK=1, AtorFK=1},
                new Personagens {IdPersonagem=2,Nome="Thor",Imagem="img_pers_2.jpg",FilmeFK=1, AtorFK=2},
                new Personagens {IdPersonagem=3,Nome="Hulk",Imagem="img_pers_3.jpg",FilmeFK=1, AtorFK=3},
                new Personagens {IdPersonagem=4,Nome="Captain America",Imagem="img_pers_4.jpg",FilmeFK=1, AtorFK=4},
                new Personagens {IdPersonagem=5,Nome="Black Widow",Imagem="img_pers_5.jpg",FilmeFK=1, AtorFK=5},
                new Personagens {IdPersonagem=6,Nome="War Machine",Imagem="img_pers_6.jpg",FilmeFK=1, AtorFK=6},
                new Personagens {IdPersonagem=7,Nome="Doctor Strange",Imagem="img_pers_7.jpg",FilmeFK=1, AtorFK=7},
                new Personagens {IdPersonagem=8,Nome="Spider-Man",Imagem="img_pers_8.jpg",FilmeFK=1, AtorFK=8},
                new Personagens {IdPersonagem=9,Nome="Black Panther",Imagem="img_pers_9.jpg",FilmeFK=1, AtorFK=9},
                new Personagens {IdPersonagem=10,Nome="Gamora",Imagem="img_pers_10.jpg",FilmeFK=1, AtorFK=10},
                new Personagens {IdPersonagem=11,Nome="Nebula",Imagem="img_pers_11.jpg",FilmeFK=1, AtorFK=11},
                new Personagens {IdPersonagem=12,Nome="Loki",Imagem="img_pers_12.jpg",FilmeFK=1, AtorFK=12},
                new Personagens {IdPersonagem=13,Nome="Vision",Imagem="img_pers_13.jpg",FilmeFK=1, AtorFK=13},
                new Personagens {IdPersonagem=14,Nome="Scarlet Witch",Imagem="img_pers_14.jpg",FilmeFK=1, AtorFK=14},
                new Personagens {IdPersonagem=15,Nome="Falcon",Imagem="img_pers_15.jpg",FilmeFK=1, AtorFK=15},
                new Personagens {IdPersonagem=16,Nome="Winter Soldier",Imagem="img_pers_16.jpg",FilmeFK=1, AtorFK=16},
                new Personagens {IdPersonagem=17,Nome="Heimdall",Imagem="img_pers_17.jpg",FilmeFK=1, AtorFK=17},
                new Personagens {IdPersonagem=18,Nome="Okoye",Imagem="img_pers_18.jpg",FilmeFK=1, AtorFK=18},
                new Personagens {IdPersonagem=19,Nome="Eitri",Imagem="img_pers_19.jpg",FilmeFK=1, AtorFK=19},
                new Personagens {IdPersonagem=20,Nome="Wong",Imagem="img_pers_20.jpg",FilmeFK=1, AtorFK=20},
                new Personagens {IdPersonagem=21,Nome="Mantis",Imagem="img_pers_21.jpg",FilmeFK=1, AtorFK=21},
                new Personagens {IdPersonagem=22,Nome="Drax",Imagem="img_pers_22.jpg",FilmeFK=1, AtorFK=22},
                new Personagens {IdPersonagem=23,Nome="Groot",Imagem="img_pers_23.jpg",FilmeFK=1, AtorFK=23},
                new Personagens {IdPersonagem=24,Nome="Rocket",Imagem="img_pers_24.jpg",FilmeFK=1, AtorFK=24},
                new Personagens {IdPersonagem=25,Nome="Pepper Potts",Imagem="img_pers_25.jpg",FilmeFK=1, AtorFK=25},
                new Personagens {IdPersonagem=26,Nome="Thanos",Imagem="img_pers_26.jpg",FilmeFK=1, AtorFK=26},
                new Personagens {IdPersonagem=27,Nome="Star-Lord",Imagem="img_pers_27.jpg",FilmeFK=1, AtorFK=27},
                new Personagens {IdPersonagem=28,Nome="Deadpool",Imagem="img_pers_28.jpg",FilmeFK=2, AtorFK=28},
                new Personagens {IdPersonagem=29,Nome="Dopinder",Imagem="img_pers_29.jpg",FilmeFK=2, AtorFK=29},
                new Personagens {IdPersonagem=30,Nome="Ajax",Imagem="img_pers_30.jpg",FilmeFK=2, AtorFK=30},
                new Personagens {IdPersonagem=31,Nome="Colossus",Imagem="img_pers_31",FilmeFK=2, AtorFK=31},
                new Personagens {IdPersonagem=32,Nome="Voice of Colossus",Imagem="img_pers_32.jpg",FilmeFK=2, AtorFK=32},
                new Personagens {IdPersonagem=33,Nome="Negasonic Teenage Warhead",Imagem="img_pers_33.jpg",FilmeFK=2, AtorFK=33},
                new Personagens {IdPersonagem=34,Nome="Jeremy (Pizza Guy)",Imagem="img_pers_34.jpg",FilmeFK=2, AtorFK=34},
                new Personagens {IdPersonagem=35,Nome="Gavin Merchant",Imagem="img_pers_35.jpg",FilmeFK=2, AtorFK=35},
                new Personagens {IdPersonagem=36,Nome="Meghan Orlovsky",Imagem="img_pers_36.jpg",FilmeFK=2, AtorFK=36},
                new Personagens {IdPersonagem=37,Nome="Buck",Imagem="img_pers_37.jpg",FilmeFK=2, AtorFK=37},
                new Personagens {IdPersonagem=38,Nome="Weasel",Imagem="img_pers_38.jpg",FilmeFK=2, AtorFK=38},
                new Personagens {IdPersonagem=39,Nome="Vanessa",Imagem="img_pers_39.jpg",FilmeFK=2, AtorFK=39},
                new Personagens {IdPersonagem=40,Nome="Angel Dust",Imagem="img_pers_40.jpg",FilmeFK=2, AtorFK=40},
                new Personagens {IdPersonagem=41,Nome="Elisa Esposito",Imagem="img_pers_41.jpg",FilmeFK=3, AtorFK=41},
                new Personagens {IdPersonagem=42,Nome="Richard Strickland",Imagem="img_pers_42.jpg",FilmeFK=3, AtorFK=42},
                new Personagens {IdPersonagem=43,Nome="Giles",Imagem="img_pers_43.jpg",FilmeFK=3, AtorFK=43},
                new Personagens {IdPersonagem=44,Nome="Zelda Fuller",Imagem="img_pers_44.jpg",FilmeFK=3, AtorFK=44},
                new Personagens {IdPersonagem=45,Nome="Dr. Robert Hoffstetler",Imagem="img_pers_45.jpg",FilmeFK=3, AtorFK=45},
                new Personagens {IdPersonagem=46,Nome="Amphibian Man",Imagem="img_pers_46.jpg",FilmeFK=3, AtorFK=46},
                new Personagens {IdPersonagem=47,Nome="Fleming",Imagem="img_pers_47.jpg",FilmeFK=3, AtorFK=47},
                new Personagens {IdPersonagem=48,Nome="General Hoyt",Imagem="img_pers_48.jpg",FilmeFK=3, AtorFK=48},
                new Personagens {IdPersonagem=49,Nome="Mihalkov",Imagem="img_pers_49.jpg",FilmeFK=3, AtorFK=49},
                new Personagens {IdPersonagem=50,Nome="Ponch",Imagem="img_pers_50.jpg",FilmeFK=4, AtorFK=50},
                new Personagens {IdPersonagem=51,Nome="Jon",Imagem="img_pers_51.jpg",FilmeFK=4, AtorFK=51},
                new Personagens {IdPersonagem=52,Nome="Ray Kurtz",Imagem="img_pers_52.jpg",FilmeFK=4, AtorFK=52},
                new Personagens {IdPersonagem=53,Nome="Ava Perez",Imagem="img_pers_53.jpg",FilmeFK=4, AtorFK=53},
                new Personagens {IdPersonagem=54,Nome="Lindsey Taylor",Imagem="img_pers_54.jpg",FilmeFK=4, AtorFK=54},
                new Personagens {IdPersonagem=55,Nome="Clay Allen",Imagem="img_pers_55.jpg",FilmeFK=4, AtorFK=55},
                new Personagens {IdPersonagem=56,Nome="Peterson",Imagem="img_pers_56.jpg",FilmeFK=4, AtorFK=56},
                new Personagens {IdPersonagem=57,Nome="Captain Jane Lindel",Imagem="img_pers_57.jpg",FilmeFK=4, AtorFK=57},
                new Personagens {IdPersonagem=58,Nome="Aurora Lane",Imagem="img_pers_58.jpg",FilmeFK=5, AtorFK=58},
                new Personagens {IdPersonagem=59,Nome="Jim Preston",Imagem="img_pers_59.jpg",FilmeFK=5, AtorFK=59},
                new Personagens {IdPersonagem=60,Nome="Arthur",Imagem="img_pers_60.jpg",FilmeFK=5, AtorFK=60},
                new Personagens {IdPersonagem=61,Nome="Gus Mancuso",Imagem="img_pers_61.jpg",FilmeFK=5, AtorFK=61},
                new Personagens {IdPersonagem=62,Nome="Captain Norris",Imagem="img_pers_62.jpg",FilmeFK=5, AtorFK=62},
                new Personagens {IdPersonagem=63,Nome="Instructor (Hologram)",Imagem="img_pers_63.jpg",FilmeFK=5, AtorFK=63}

            };
            personagens.ForEach(pp => context.Personagens.AddOrUpdate(p => p.IdPersonagem, pp));
            context.SaveChanges();
            
        }
    }
}
