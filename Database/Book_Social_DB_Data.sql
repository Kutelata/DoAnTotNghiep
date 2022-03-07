insert into [Role] values
('User',0),
('Admin',1),
('Library Manager',0),
('User Manager',0)
go

insert into Permission values
('')
go

insert into Role_Permission values
('')
go

insert into [User] values
('Long','0832536199','hclong2k@gmail.com','admin','admin123','','Ha Noi','Form is temporary but class is permanent !','2000-01-23',1,'',1,1),
('Cong Phuong','0832536199','congphuong@gmail.com','user','user123','','Ho Chi Minh','Today is the good day to die !','2000-02-23',1,'',1,2),
('Quang Hai','0832536199','quanghai@gmail.com','library','library123','','Hai Phong','Form is temporary but class is permanent !','2000-03-23',1,'',1,3),
('Xuan Truong','0832536199','xuantruong@gmail.com','manager','manager123','','Da Nang','Form is temporary but class is permanent !','2000-04-23',1,'',1,4)
go

insert into Author values
('Laura Gao','image','description','birthday'),
go

insert into Genre values
('Sports'),
('Travel'),
('Self-Help'),
('Poetry'),
('Science'),
('Business'),
('Comic'),
('Detective'),
('Music'),
('History')
go

insert into Book values
('0063067773','Messy Roots: A Graphic Memoir of a Wuhanese American','Messy_Roots_A_Graphic_Memoir_of_a_Wuhanese_American.jpg','"Messy Roots is a laugh-out-loud, heartfelt, and deeply engaging story of their journey to find themself--as an American, as the daughter of Chinese immigrants, as a queer person, and as a Wuhanese American in the middle of a pandemic."—Malaka Gharib, author of I Was Their American Dream

After spending her early years in Wuhan, China, riding water buffalos and devouring stinky tofu, Laura immigrates to Texas, where her hometown is as foreign as Mars—at least until 2020, when COVID-19 makes Wuhan a household name.

In Messy Roots, Laura illustrates her coming-of-age as the girl who simply wants to make the basketball team, escape Chinese school, and figure out why girls make her heart flutter.

Insightful, original, and hilarious, toggling seamlessly between past and present, China and America, Gao’s debut is a tour de force of graphic storytelling.',272,'2022-03-08',0,'English',0,7),
('1419749579','Pixels of You','Pixels_of_You.jpg','A human and human-presenting AI slowly become friends—and maybe more—in this moving YA graphic novel

In a near future, augmentation and AI changed everything and nothing. Indira is a human girl who has been cybernetically augmented after a tragic accident, and Fawn is one of the first human-presenting AI. They have the same internship at a gallery, but neither thinks much of the other’s photography. But after a huge public blowout, their mentor gives them an ultimatum: work together on a project or leave her gallery forever. Grudgingly, the two begin to collaborate, and what comes out of it is astounding and revealing for both of them. Pixels of You is about the slow transformation of a rivalry to a friendship to something more as Indira and Fawn navigate each other, the world around them—and what it means to be an artist and a person.',172,'2022-02-08',0,'English',0,7),
('168415524X','A Thief Among the Trees','A_Thief_Among_the_Trees.jpg','Taking place years before the bestselling An Ember in the Ashes novel series, this standalone original graphic novel follows three young military recruits: Elias, Helene, and Tavi, during their brutal training as soldiers for the Martial Empire. 

WITHIN THE EMPIRE THERE ARE NO QUESTIONS, ONLY ORDERS.

Elias, Helene and Tavi are Fivers --in training to become elite military recruits for the Martial Empire at Blackcliff Academy. When they’re sent on a dangerous mission to steal a heavily-guarded poison on Isle South, they soon find themselves up against surprising enemies -- including other recruits. As the true horror of their assignment is revealed, these three will begin to confront the harrowing realities of Martial rule, their place in the system . . . and the choices they must make to survive.
 
New York Times bestselling author Sabaa Tahir joins writer Nicole Andelfinger and artist Sonia Liao for an all-new original graphic novel revealing an early tale of Elias and Helene at Blackcliff, and a stirring standalone chapter in the An Ember in the Ashes mythology.',144,'2020-07-14',1,'English',0,7),
(0,'name','.jpg','description',0,'published','language',7),
(0,'name','.jpg','description',0,'published','language',7),
(0,'name','.jpg','description',0,'published','language',7),
(0,'name','.jpg','description',0,'published','language',7),
(0,'name','.jpg','description',0,'published','language',7),
(0,'name','.jpg','description',0,'published','language',7),
(0,'name','.jpg','description',0,'published','language',7),
go

insert into Author_Book values
('')
go

insert into Progress_Book values
('Read'),
('Currently Reading'),
('Want to read')
go

insert into [Group] values
('')
go

insert into [User_Activity] values
('')
go

insert into [Like] values
('')
go
