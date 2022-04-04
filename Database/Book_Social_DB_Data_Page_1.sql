insert into [User] values
-- ('name','phone','email','account','password','image','address','description','birthday','gender','friend','status','role_id')

('Cong Phuong','0832536199','congphuong@gmail.com','user','user123','','Ho Chi Minh','Today is the good day to die !','2000-02-23',1,'',1,0),
('Long','0832536199','hclong2k@gmail.com','admin','admin123','','Ha Noi','Form is temporary but class is permanent !','2000-11-23',1,'',1,1),
('Quang Hai','0832536199','quanghai@gmail.com','library','library123','','Hai Phong','','2000-03-23',1,'',1,2),
('Xuan Truong','0832536199','xuantruong@gmail.com','manager','manager123','','Da Nang','','2000-04-23',1,'',1,3)
go

insert into Genre values
-- ('name')

('Art'),
('Business'),
('Comic'),
('Self-Help'),
('Sport')
go

insert into Book values
-- ('isbn','name','image','description','page_number','published','genre_id'),

('1534439463','Ain''t Burned All the Bright','Aint_Burned_All_the_Bright.jpg','Jason Reynolds and his best bud, Jason Griffin had a mind-meld. And they decided to tackle it, in one fell swoop, in about ten sentences, and 300 pages of art, this piece, this contemplation-manifesto-fierce-vulnerable-gorgeous-terrifying-WhatIsWrongWithHumans-hope-filled-hopeful-searing-Eye-Poppingly-Illustrated-tender-heartbreaking-how-The-HECK-did-They-Come-UP-with-This project about oxygen. And all of the symbolism attached to that word, especially NOW.',384,'2022-11-02',1),
('0063082586','Fake: A Novel','Fake.jpg','She''s a forger, an artist who specializes in nineteenth-century paintings. But she isn’t a criminal; her copies are commissioned by museums and ultra-wealthy collectors protecting their investments. Emma’s more than mastered a Gauguin brushstroke and a van Gogh wheat field, but her work is sometimes a painful reminder of the artistic dreams she once chased for herself, when she was younger and before her family and her world fell apart.',320,'2022-02-22',1),
('0156454890','Italian Folktales','Italian_Folktales.jpg','Filled with kings and peasants, saints and ogres—as well as some quite extraordinary plants and animals—these two hundred tales bring to life Italy’s folklore, sometimes with earthy humor, sometimes with noble mystery, and sometimes with the playfulness of sheer nonsense.',800,'1992-11-15',1),
('168198847X','Morpho: Clothing Folds and Creases: Anatomy for Artists','Morpho_Clothing_Folds_and_Creases_Anatomy_for_Artists.jpg','In Morpho: Clothing Folds and Creases, artist and teacher Michel Lauricella presents a unique approach to learning to draw clothing. By connecting the underlying anatomy to clothing, as well as considering the body''s posture and movement, you can learn to draw accurate and realistic clothing. Whether you''re interested in art, animation, or fashion, this book is a great resource for anyone sketching or drawing clothing.',96,'2022-02-22',1),
('0385547358','Other People''s Clothes: A Novel','Other_People_Clothes.jpg','Hoping to escape the pain of the recent murder of her best friend, art student Zoe Beech finds herself studying abroad in the bohemian capital of Europe—Berlin. Rudderless, Zoe relies on the arrangements of fellow exchange student Hailey Mader, who idolizes Warhol and Britney Spears and wants nothing more than to be an art star.',320,'2022-02-01',1),
('141974870X','The Art of Star Wars: The Mandalorian','The_Art_of_Star_Wars_The_Mandalorian.jpg','The Art of Star Wars: The Mandalorian takes fans behind the scenes of the first ever live-action Star Wars television series. Filled with concept art, sketches, and interviews with key cast, crew, and creatives, including executive producer/showrunner/writer Jon Favreau and executive producer/director Dave Filoni, The Art of Star Wars: The Mandalorian will provide readers with an exclusive look at a whole new universe of Star Wars characters, locations, and vehicles.',256,'2020-12-01',1),
('1542019125','The Singing Trees: A Novel','The_Singing_Trees.jpg','Maine, 1969. After losing her parents in a car accident, aspiring artist Annalisa Mancuso lives with her grandmother and their large Italian family in the stifling factory town of Payton Mills. Inspired by her mother, whose own artistic dreams disappeared in a damaged marriage, Annalisa is dedicated only to painting. Closed off to love, and driven as much by her innate talent as she is the disillusionment of her past, Annalisa just wants to come into her own.',429,'2021-08-03',1),
('9780140549058','Why Mosquitoes Buzz in People''s Ears: A West African Tale','Why_Mosquitoes_Buzz_in_People_Ears.jpg','"In this Caldecott Medal winner, Mosquito tells a story that causes a jungle disaster. "Elegance has become the Dillons'' hallmark. . . . Matching the art is Aardema''s uniquely onomatopoeic text . . . An impressive showpiece."
-Booklist, starred review.',32,'2004-08-15',1),
('383658560X','Witchcraft. The Library of Esoterica','Witchcraft_The_Library_of_Esoterica.jpg','Initiating readers in the fascinating and complex history of witchcraft, from the goddess mythologies of ancient cultures to the contemporary embrace of the craft by modern artists and activists, this expansive tome conjures up a breathtaking overview of an age-old tradition. Rooted in legend, folklore, and myth, the archetype of the witch has evolved from the tales of Odysseus and Circe, the Celtic seductress Cerridwen, and the myth of Hecate, fierce ruler of the moonlit night. In Witchcraft we survey her many incarnations since, as she shape-shifts through the centuries, alternately transforming into mother, nymph, and crone―seductress and destroyer.',520,'2021-10-28',1),
('B08QQZQTVM','Write My Name Across the Sky: A Novel','Write_My_Name_Across_the_Sky.jpg','Life’s beautiful for seventysomething influencer Gloria Rose, in her Upper West Side loft with rooftop garden and scores of Instagram followers—until she gets word that her old flame has been arrested for art theft and forgery, and, knowing her own involvement in his misdeeds decades earlier, decides to flee. But that plan is complicated when the nieces she raised are thrown into crises of their own.',361,'2021-08-10',1),

('164712154X','Being Present: Commanding Attention at Work (and at Home) by Managing Your Social Presence','Being_Present.jpg','As our ability to pay attention in a world of distractions vanishes, it''s no wonder that our ability to be heard and understood - to convey our messages - is also threatened. Whether working with our teams and customers or communicating with our families and friends, it is increasingly difficult to break through the digital devices that get in the way of communication. And the ubiquity of digital devices means that we are often "multicommunicating," participating in multiple conversations at once. As a result, our ability to be socially present with an audience requires an intentional approach.',207,'2022-01-11',2),
('1544512287','Can''t Hurt Me: Master Your Mind and Defy the Odds','Cant_Hurt_Me.jpg','For David Goggins, childhood was a nightmare -- poverty, prejudice, and physical abuse colored his days and haunted his nights. But through self-discipline, mental toughness, and hard work, Goggins transformed himself from a depressed, overweight young man with no future into a U.S. Armed Forces icon and one of the world''s top endurance athletes. The only man in history to complete elite training as a Navy SEAL, Army Ranger, and Air Force Tactical Air Controller, he went on to set records in numerous endurance events, inspiring Outside magazine to name him "The Fittest (Real) Man in America."',364,'2018-12-04',2),
('1400226945','Hero on a Mission: A Path to a Meaningful Life','Hero_on_a_Mission.jpg','In this book, bestselling author Donald Miller uses his own experiences to help you recognize if the character you are currently surfacing is helping you experience a life of meaning. He breaks down the transformational, yet practical, plan that took him from slowly giving up to rapidly gaining a new perspective of his own life’s beauty and meaning, igniting his motivation, passion, and productivity, so you can do the same.',224,'2022-01-11',2),
('1982165448','Making Numbers Count: The Art and Science of Communicating Numbers','Making_Numbers.jpg','Understanding numbers is essential—but humans aren’t built to understand them. Until very recently, most languages had no words for numbers greater than five—anything from six to infinity was known as “lots.” While the numbers in our world have gotten increasingly complex, our brains are stuck in the past. How can we translate millions and billions and milliseconds and nanometers into things we can comprehend and use?',208,'2022-01-11',2),
('0062889443','Rise: My Story','Rise_My_Story.jpg','A fixture in the American sports landscape for almost twenty years, Lindsey Vonn is a legend. With a career that spanned a transformation in how America recognizes and celebrates female athletes, Vonn—who retired in 2019 as the most decorated American skier of all time—was in the vanguard of that change, helping blaze a trail for other world-class female athletes and reimagining what it meant to pursue speed at all costs.',336,'2022-01-11',2),
('1647821150','Smart Growth: How to Grow Your People to Grow Your Company','Smart_Growth.jpg','Growth is the goal. Helping people develop their potential—enabling them to articulate and become the self they want to be, are capable of being, and that best serves them and others in the short and long term—is what we as individuals and leaders strive toward.',240,'2022-01-11',2),
('0691147132','Spies, Lies, and Algorithms: The History and Future of American Intelligence','Spies_Lies_and_Algorithms.jpg','Spying has never been more ubiquitous―or less understood. The world is drowning in spy movies, TV shows, and novels, but universities offer more courses on rock and roll than on the CIA and there are more congressional experts on powdered milk than espionage. This crisis in intelligence education is distorting public opinion, fueling conspiracy theories, and hurting intelligence policy. In Spies, Lies, and Algorithms, Amy Zegart separates fact from fiction as she offers an engaging and enlightening account of the past, present, and future of American espionage as it faces a revolution driven by digital technology.',424,'2022-02-01',2),
('1501197266','The Founders: The Story of Paypal and the Entrepreneurs Who Shaped Silicon Valley','The_Founders_The_Story_of_Paypal.jpg','Today, PayPal’s founders and earliest employees are considered the technology industry’s most powerful network. Since leaving PayPal, they have formed, funded, and advised the leading companies of our era, including Tesla, Facebook, YouTube, SpaceX, Yelp, Palantir, and LinkedIn, among many others. As a group, they have driven twenty-first-century innovation and entrepreneurship. Their names stir passions; they’re as controversial as they are admired.',496,'2022-02-22',2),
('0735210659','The Power of Regret: How Looking Backward Moves Us Forward','The_Power_of_Regret.jpg','Everybody has regrets, Daniel H. Pink explains in The Power of Regret. They’re a universal and healthy part of being human. And understanding how regret works can help us make smarter decisions, perform better at work and school, and bring greater meaning to our lives.',256,'2022-02-01',2),
('0593239482','The Voltage Effect: How to Make Good Ideas Great and Great Ideas Scale','The_Voltage_Effect.jpg','“Scale” has become a favored buzzword in the startup world. But scale isn''t just about accumulating more users or capturing more market share. It''s about whether an idea that takes hold in a small group can do the same in a much larger one—whether you’re growing a small business, rolling out a diversity and inclusion program, or delivering billions of doses of a vaccine.',288,'2022-02-01',2),

('168415524X','A Thief Among the Trees: An Ember in the Ashes Graphic Novel','A_Thief_Among_the_Trees.jpg','Elias, Helene and Tavi are Fivers --in training to become elite military recruits for the Martial Empire at Blackcliff Academy. When they’re sent on a dangerous mission to steal a heavily-guarded poison on Isle South, they soon find themselves up against surprising enemies -- including other recruits. As the true horror of their assignment is revealed, these three will begin to confront the harrowing realities of Martial rule, their place in the system . . . and the choices they must make to survive.',144,'2020-07-14',3),
('0593124138','Across a Field of Starlight: (A Graphic Novel)','Across_a_Field_of_Starlight.jpg','When they were kids, Fassen’s fighter spaceship crash-landed on a planet that Lu’s survey force was exploring. It was a forbidden meeting between a kid from a war-focused resistance movement and a kid whose community and planet are dedicated to peace and secrecy.',352,'2022-02-08',3),
('1779514328','Batman: The Imposter','Batman_The_Imposter.jpg','Mattson Tomlin–creator of the hit Netflix series Project Power and director of the upcoming Mother/Android–has teamed up with Eisner-winning suspense and horror artist Andrea Sorrentino (JOKER: KILLER SMILE, Gideon Falls) to create a wholly new version of Gotham City, informed by grim reality, where every punch leaves a broken bone and every action has consequences far, far beyond Batman’s imagination!',168,'2022-02-22',3),
('B09MZS6K81','Harley Quinn: The Animated Series: The Eat. Bang! Kill. Tour','Harley_Quinn_The_Animated.jpg','While Ivy starts reflecting on what’s been happening these last few months after leaving Kite Man at the altar and joining Harley Quinn for a de facto, impromptu honeymoon across the DCU, new villain Mephitic makes himself known to Harley and Ivy at the Black Cat Lounge.',23,'2022-02-03',3),
('0063067765','Messy Roots: A Graphic Memoir of a Wuhanese American','Messy_Roots.jpg','After spending her early years in Wuhan, China, riding water buffalos and devouring stinky tofu, Laura immigrates to Texas, where her hometown is as foreign as Mars—at least until 2020, when COVID-19 makes Wuhan a household name.',272,'2022-03-08',3),
('1419749579','Pixels of You','Pixels_of_You.jpg','In a near future, augmentation and AI changed everything and nothing. Indira is a human girl who has been cybernetically augmented after a tragic accident, and Fawn is one of the first human-presenting AI. They have the same internship at a gallery, but neither thinks much of the other’s photography. But after a huge public blowout, their mentor gives them an ultimatum: work together on a project or leave her gallery forever. Grudgingly, the two begin to collaborate, and what comes out of it is astounding and revealing for both of them. Pixels of You is about the slow transformation of a rivalry to a friendship to something more as Indira and Fawn navigate each other, the world around them—and what it means to be an artist and a person.',172,'2022-02-08',3),
('1945820837','Real Hero Shit','Real_Hero_Shit.jpg','Every day is basically spring break for Eugene, but outside the palace walls he crashes into a hard reality: the system that kept him safe in his silk-sheeted bed isn''t particularly concerned with the well-being of anyone who isn''t him. Eugene will have to level-up his awareness if he means to be a real hero, and time is running short!',120,'2022-02-01',3),
('1684158052','The Many Deaths of Laila Starr','The_Many_Deaths_of_Laila_Starr.jpg','Humanity is on the verge of discovering immortality. As a result, the avatar of Death is cast down to Earth to live a mortal life in Mumbai as twenty-something Laila Starr. Struggling with her newfound mortality, Laila has found a way to be placed in the time and place where the creator of immortality will be born. Will Laila take her chance to stop mankind from permanently altering the cycle of life, or will death really become a thing of the past? A powerful new graphic novel from award-winning writer Ram V (These Savage Shores, Swamp Thing) and Filipe Andrade (Captain Marvel) that explores the fine line between living and dying through the lens of magical realism. Collects The Many Deaths of Laila Starr #1-5.',128,'2022-02-01',3),
('1302928074','Way of X by Si Spurrier','Way_of_X_by_Simon_Spurrier.jpg','Only one mutant senses the looming shadows. On Krakoa, mutantkind has built a new Eden — but there are serpents in this garden. Some mutants struggle to fit in. Some mutants turn to violence and death. And the children whisper of the Patchwork Man, singing in their hearts. Snared by questions of death, law and love, only Nightcrawler can fight for the soul of Krakoa. Only he — and the curious crew he assembles — can help mutants defeat their inner darkness and find a new way to live! But the malevolent force hiding within Krakoa has begun to show its true form, and answers are hidden…within the Mindscape! As the X-Men’s greatest foe — mutantkind’s primal evil — slithers in the minds of its most senior leaders, can Nightcrawler light the spark that will drive out the shadows, or will Krakoa slip into the abyss?',192,'2022-02-22',3),
('1637150180','Witchy','Witchy.jpg','',184,'2022-02-12',3),

('1592408419','Daring Greatly: How the Courage to Be Vulnerable Transforms the Way We Live, Love, Parent, and Lead','Daring_Greatly.jpg','Every day we experience the uncertainty, risks, and emotional exposure that define what it means to be vulnerable or to dare greatly. Based on twelve years of pioneering research, Brené Brown PhD, MSW, dispels the cultural myth that vulnerability is weakness and argues that it is, in truth, our most accurate measure of courage.',320,'2015-04-07',4),
('0671027034','How to Win Friends & Influence People','How_to_Win_Friends_and_Influence_People.jpg','Dale Carnegie’s rock-solid, time-tested advice has carried countless people up the ladder of success in their business and personal lives.',320,'1998-10-01',4),
('B07WF972WK','The 7 Habits of Highly Effective People: 30th Anniversary Edition','The_7_Habits_of_Highly_Effective_People.jpg','This beloved classic presents a principle-centered approach for solving both personal and professional problems. With penetrating insights and practical anecdotes, Stephen R. Covey reveals a step-by-step pathway for living with fairness, integrity, honesty, and human dignity—principles that give us the security to adapt to change and the wisdom and power to take advantage of the opportunities that change creates.',447,'2020-10-20',4),
('9781878424310','The Four Agreements: A Practical Guide to Personal Freedom (A Toltec Wisdom Book)','The_Four_Agreements.jpg','“In the tradition of Castaneda, Ruiz distills essential Toltec wisdom, expressing with clarity and impeccability what it means for men and women to live as peaceful warriors in the modern world.” — Dan Millman, Author, Way of the Peaceful Warrior',160,'2018-07-10',4),
('B085LLCPT5','The Gifts of Imperfection, 10th Anniversary Edition: Features a New Foreword','The_Gifts_of_Imperfection.jpg','What transforms this book from words to effective daily practices are the 10 guideposts to wholehearted living. The guideposts not only help us understand the practices that will allow us to change our lives and families, they also walk us through the unattainable and sabotaging expectations that get in the way.',89,'2019-07-10',4),
('1607747308','The Life-Changing Magic of Tidying Up: The Japanese Art of Decluttering and Organizing','The_Life_Changing_Magic_of_Tidying_Up.jpg','Japanese cleaning consultant Marie Kondo takes tidying to a whole new level, promising that if you properly simplify and organize your home once, you’ll never have to do it again. Most methods advocate a room-by-room or little-by-little approach, which doom you to pick away at your piles of stuff forever. The KonMari Method, with its revolutionary category-by-category system, leads to lasting results. In fact, none of Kondo’s clients have lapsed (and she still has a three-month waiting list).',224,'2014-10-14',4),
('1955423393','Power of Habit: Rewire Your Brain to Build Better Habits and Unlock Your Full Potential','The_Power_of_Habit.jpg','Success is something that every person is streaming towards – it''s in our blood (literally). The feeling that we have when we accomplish something is a product of the release of neuroactive compounds in our brains',146,'2021-07-15',4),
('0307352153','Quiet: The Power of Introverts in a World That Can''t Stop Talking','The_Power_of_Introverts.jpg','At least one-third of the people we know are introverts. They are the ones who prefer listening to speaking; who innovate and create but dislike self-promotion; who favor working on their own over working in teams. It is to introverts—Rosa Parks, Chopin, Dr. Seuss, Steve Wozniak—that we owe many of the great contributions to society.',368,'2013-01-29',4),
('1577314808','The Power of Now: A Guide to Spiritual Enlightenment','The_Power_of_Now.jpg','In the first chapter, Tolle introduces readers to enlightenment and its natural enemy, the mind. He awakens readers to their role as a creator of pain and shows them how to have a pain-free identity by living fully in the present. The journey is thrilling, and along the way, the author shows how to connect to the indestructible essence of our Being, "the eternal, ever-present One Life beyond the myriad forms of life that are subject to birth and death."',236,'2004-08-01',4),
('9780762447695','You Are a Badass: How to Stop Doubting Your Greatness and Start Living an Awesome Life','You_Are_a_Badass.jpg','In this refreshingly entertaining how-to guide, bestselling author and world-traveling success coach, Jen Sincero, serves up 27 bitesized chapters full of hilariously inspiring stories, sage advice, easy exercises, and the occasional swear word, helping you to: Identify and change the self-sabotaging beliefs and behaviors that stop you from getting what you want, Create a life you totally love. And create it NOW, Make some damn money already. The kind you''ve never made before.',256,'2013-04-23',4),

('B08BZNQN7X','Always Only You','Always_Only_You.jpg','The moment I met her, I knew Frankie Zeferino was someone worth waiting for. Deadpan delivery, secret heart of gold, and a rare one-dimpled smile that makes my knees weak, Frankie has been forbidden since the day she and I became coworkers, meaning waiting has been the name of my game—besides, hockey, that is.',370,'2020-08-04',5),
('1629379344','Fearless Heart: An Illustrated Biography of Surya Bonaly','Fearless_Heart.jpg','Her colorful costumes, exuberant routines, powerful jumps, and daring combinations were all expressions of her love for skating and her ambition to push the boundaries of what a figure skating champion could look like.',32,'2022-01-25',5),
('B093G8LW2W','Getting His Game Back: A Novel','Getting_His_Game_Back.jpg','Khalil Sarda went through a rough patch last year, but now he’s nearly back to his old self. All he has to do is keep his “stuff” in the past. Real men don’t have depression and go to therapy—or, at least they don’t admit it. He’s ready to focus on his growing chain of barbershops, take care of his beloved Detroit community, and get back to being the ladies’ man his family and friends tease him for being. It’ll be easy . . . until Vanessa throws him completely off his game. ',317,'2022-01-25',5),
('B08C9X5R1G','Hands Down','Hands_Down.jpg','She thinks she’s ready when a call has her walking back into her old friend’s life. Or at least as prepared as possible to see the starting quarterback in the National Football Organization. Before the lights, the fans, and the millions, he’d been a skinny kid with a heart of gold.',550,'2020-07-02',5),
('B07FTWJR4C','Heart of Hope: A Small Town Romance','Heart_of_Hope.jpg','To be fair, I practically threw myself at his crotch. And okay, fine. Getting naked with him was the first time I’d felt anything worth feeling since losing my little sister. It’s almost kinda nice to be fueled by the fires of rage instead of the numbness of grief. But I’m certainly not going to thank him for lying and then sneaking out of my bed like a thief in the midafternoon.',222,'2018-07-23',5),
('1250777119','Icebreaker','Icebreaker.jpg','The only person standing in his way is Jaysen Caulfield, a contender for the #1 spot and Mickey''s infuriating (and infuriatingly attractive) teammate. When rivalry turns to something more, Mickey will have to decide what he really wants, and what he''s willing to risk for it.',320,'2022-01-18',5),
('B08TVFZ44W','Sooley: A Novel','Sooley.jpg','In the summer of his seventeenth year, Sam­uel Sooleymon gets the chance of a lifetime: a trip to the United States with his South Sudanese teammates to play in a showcase basket­ball tournament. He has never been away from home, nor has he ever been on an airplane. The opportunity to be scouted by dozens of college coaches is a dream come true.',354,'2021-04-27',5),
('B09CGFPGHQ','The Cheat Sheet: A Novel','The_Cheat_Sheet.jpg','Nothing but good old-fashioned, no-touching-the-sexiest-man-alive, platonic friendship for us! Everything is exactly how I like it! Yes. Good. (I’m not crying, I’m just peeling an onion.)',304,'2021-08-17',5),
('B08VRXJZ5H','The Fastest Way to Fall','The_Fastest_Way_to_Fall.jpg','As CEO of the FitMi Fitness app, Wes Lawson finally has the financial security he grew up without, but despite his success, his floundering love life and complicated family situation leaves him feeling isolated and unfulfilled. He decides to get back to what he loves—coaching. Britta’s his first new client and they click immediately.',380,'2021-11-02',5),
('B0942XMXF7','The Horsewoman','The_Horsewoman.jpg','Coronado is Maggie’s horse. An absolutely top-tier Belgian warmblood. 
Sky is Becky’s horse. A small, speedy Dutch warmblood.',450,'2022-01-10',5)
go
