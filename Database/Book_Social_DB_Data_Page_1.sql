insert into [Role] values
-- ('name')

('User'),
('Admin'),
('Library Manager'),
('User Manager')
go

insert into [User] values
-- ('name','phone','email','account','password','image','address','description','birthday','gender','friend','status','role_id')

('Cong Phuong','0832536199','congphuong@gmail.com','user','user123','','Ho Chi Minh','Today is the good day to die !','2000-02-23',1,'',1,1),
('Long','0832536199','hclong2k@gmail.com','admin','admin123','','Ha Noi','Form is temporary but class is permanent !','2000-11-23',1,'',1,2),
('Quang Hai','0832536199','quanghai@gmail.com','library','library123','','Hai Phong','','2000-03-23',1,'',1,3),
('Xuan Truong','0832536199','xuantruong@gmail.com','manager','manager123','','Da Nang','','2000-04-23',1,'',1,4)
go

insert into Author values
-- ('name','image','description','birthday')

('Jason Reynolds','image','description','birthday'),
('Erica Katz','image','description','birthday'),
('Italo Calvino','image','description','birthday'),
('Michel Lauricella','image','description','birthday'),
('Calla Henkel','image','description','birthday'),
('Abrams Books','image','description','birthday'),
('Boo Walker','image','description','birthday'),
('Verna Aardema','image','description','birthday'),
('Pam Grossman','image','description','birthday'),
('Jessica Hundley','image','description','birthday'),

('Barbara O''Neal','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),

('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),

('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),

('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday'),
('','image','description','birthday')
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

('164712154X','Being Present: Commanding Attention at Work (and at Home) by Managing Your Social Presence','Being_Present.jpg','As our ability to pay attention in a world of distractions vanishes, it''s no wonder that our ability to be heard and understood - to convey our messages - is also threatened. Whether working with our teams and customers or communicating with our families and friends, it is increasingly difficult to break through the digital devices that get in the way of communication. And the ubiquity of digital devices means that we are often "multicommunicating," participating in multiple conversations at once. As a result, our ability to be socially present with an audience requires an intentional approach.',207,'2022-01-11',2)
go
