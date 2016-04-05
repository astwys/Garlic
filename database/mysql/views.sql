use garlic;


# get all votes from articles / comments as well as the total of votes of a user
drop view if exists vUserVotes;
create view vUserVotes as
	select u.u_username as uu_user,
		(
		 	select count(*)
		 	from a_articles a inner join (p_posts p inner join v_votes v
	 	                            		on p.p_id = v.v_p_post)
		 		on a.a_p_id = p.p_id
 				where u.u_username like p.p_u_username
		 ) as uu_articles_upvotes,
		(
		select count(*)
	 	from c_comments c inner join (p_posts p inner join v_votes v
	 	                            		on p.p_id = v.v_p_post)
	 		on c.c_p_id = p.p_id
			where u.u_username like p.p_u_username
		 ) as uu_comments_upvotes,
		(
		 select count(*)
		 from v_votes v inner join p_posts p
		 	on v.v_p_post = p.p_id
		 	where u.u_username like p.p_u_username
		 ) as uu_total_upvotes
	from u_users u;

select * from vUserVotes;


drop view if exists vUserRankings;
create view vUserRankings as
	select u.u_username,
	(
	 select count(*)
	 from p_posts p inner join a_articles a
	 		on p.p_id = a.a_p_id
		where a.a_r_rank between 1 and 499 and p.p_u_username like u.u_username
	 ) as ur_superhot,
	(
	 select count(*)
	 from p_posts p inner join a_articles a
 			on p.p_id = a.a_p_id
		where a.a_r_rank between 500 and 999 and p.p_u_username like u.u_username
	 ) as ur_hot,
	(
	 select count(*)
	 from p_posts p inner join a_articles a
	 		on p.p_id = a.a_p_id
		where a.a_r_rank between 1000 and 1499 and p.p_u_username like u.u_username
	 ) as ur_rising,
	(
	 select count(*)
	 from p_posts p inner join a_articles a
	 		on p.p_id = a.a_p_id
		where a.a_r_rank between 1500 and 2000 and p.p_u_username like u.u_username
	 ) as ur_upcoming,
	(
	 select count(*)
	 from p_posts p inner join a_articles a
	 		on p.p_id = a.a_p_id
		where p.p_u_username like u.u_username
	 ) as ur_total
	from u_users u;

select * from vUserRankings;