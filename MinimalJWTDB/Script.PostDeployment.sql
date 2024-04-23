if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (username, password, email, givenName, surname, role)
	values('Aubrey', 'Carrots2k17', 'aubzcrt@gmail.com', 'Carrots', 'Carrots', 'admin'),
	('Teddy', 'Charming123', 'teddie@gmail.com', 'Teddie', 'Charming', 'standard'),
	('Sue','xmen97', 'sue@gmail.com', 'Sue', 'Storm', 'standard'),
	('Mary', 'spidey123','mj@gmail.com', 'MJ', 'Jane', 'Team Leader' ),
	('Fuzzy', 'zoo256', 'fuzzy@gmail.com', 'Fuzzy', 'Zootophia', 'admin')
end

if not exists (select 1 from dbo.[Movies])
begin 
	insert into dbo.[Movies] (title, description, rating)
	values('Eternals', 'The saga of the Eternals, a race of immortal beings who lived on earth and shaped history and civilizations', '6.8'),
	('Dune', 'A noble family becomes embroiled in a war for control over the galaxy''s most valuable asset while its heir becomes troubled by visions of a dark future.', '8.2'),
	('Avengers', 'Thor enlists the help of Valkyrie, Korg and ex-girlfriend Jane Foster to fight Gorr the God Butcher, who intends to make the gods extinct.', '7.2')

end
