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
		 ) as uu_articles_votes,
		(
		select count(*)
	 	from c_comments c inner join (p_posts p inner join v_votes v
	 	                            		on p.p_id = v.v_p_post)
	 		on c.c_p_id = p.p_id
			where u.u_username like p.p_u_username
		 ) as uu_comments_votes,
		(
		 select count(*)
		 from v_votes v inner join p_posts p
		 	on v.v_p_post = p.p_id
		 	where u.u_username like p.p_u_username
		 ) as uu_total_votes
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


# get every post with the user who created it 
# as well as all the votes the post has gotten so far
drop view if exists vPostInfo;
create view vPostInfo as
	select p.p_id as pi_postID, p.p_date as pi_postDate, p.p_content as pi_postContent,
	(
	 select u.u_username
	 from u_users u
	 where u.u_username = p.p_u_username
	 ) as pi_user,
	(
	 select count(*)
	 from v_votes v
	 where v.v_p_post = p.p_id
	 ) as pi_votes,
	 (
	  select count(*)
	  from c_comments c
	  where c.c_p_commentOf = p.p_id
	 ) as pi_comments,
	 (
	  select a.a_title
	  from a_articles a
	  where a.a_p_id = p.p_id
	 ) as pi_postTitle
	from p_posts p
	order by pi_postID asc;

select * from vPostInfo;


# get the number of subscribers and admins per clove
drop view if exists vCloveInfo;
create view vCloveInfo as
	select c.c_id as ci_cloveID, c.c_name as ci_cloveName,
	(
	 select count(*)
	 from s_subscriptions s
	 where s.s_c_clove = c.c_id
	 ) as ci_subscribers,
	(
	 select count(*)
	 from ad_admins ad
	 where ad.ad_c_clove = c.c_id
	 ) as ci_admins,
	(
	 select count(*)
	 from a_articles a
	 where a.a_c_clove = c.c_id
	 ) as ci_articles
	from c_clove c;

select * from vCloveInfo;


# select all the data needed for the homepage of the asp.net client
drop view if exists vCloveArticles;
create view vCloveArticles as 
	select a.a_p_id, a.a_title, a.a_c_clove, p.p_u_username,
	(
	 select c.c_name
	 from c_clove c
	 where c.c_id = a.a_c_clove
	 ) as cloveName,
	(
	 select c_access
	 from c_clove c
	 where c.c_id = a.a_c_clove
	 ) as isPublic,
	(
	 select c.c_description
	 from c_clove c
	 where c.c_id = a.a_c_clove
	 ) as cloveDesc,
	(
	 select count(*)
	 from c_comments co
	 where co.c_p_commentOf = p.p_id
	 ) as commentCount,
	(
	 select count(*)
	 from v_votes v
	 where v.v_p_post = p.p_id
	 ) as voteCount
	from p_posts p inner join a_articles a
		on p.p_id = a.a_p_id;

select * from vCloveArticles;