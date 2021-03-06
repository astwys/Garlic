use garlic;

# I had to use the absolute path as the database itself is saved in another location
# which has no relation to the location the data-files are stored in

# the data used can be found here: https://github.com/astwys/Garlic/tree/master/database/mysql/data

set foreign_key_checks = 0;

#u_users
delete from u_users;
load data infile '/Users/michael/school/3EHIF/DBI/Garlic/database/mysql/data/u_users.csv'
into table u_users
fields terminated by ','
lines terminated by '\n'
ignore 1 rows;

#p_posts
delete from p_posts;
load data infile '/Users/michael/school/3EHIF/DBI/Garlic/database/mysql/data/p_posts.csv'
into table p_posts
fields terminated by ','
optionally enclosed by '"'
lines terminated by '\n'
ignore 1 rows;

#c_clove
delete from c_clove;
load data infile '/Users/michael/school/3EHIF/DBI/Garlic/database/mysql/data/c_cloves.csv'
into table c_clove
fields terminated by ','
optionally enclosed  by '"'
lines terminated by '\n'
ignore 1 rows;

#ad_admins	done
delete from ad_admins;
load data infile '/Users/michael/school/3EHIF/DBI/Garlic/database/mysql/data/ad_admins.csv'
into table ad_admins
fields terminated by ','
lines terminated by '\n'
ignore 1 rows;

#s_subscriptions
delete from s_subscriptions;
load data infile '/Users/michael/school/3EHIF/DBI/Garlic/database/mysql/data/s_subscriptions.csv'
into table s_subscriptions
fields terminated by ','
lines terminated by '\n'
ignore 1 rows;

#sm_socialmedias
delete from sm_socialmedias;
load data infile '/Users/michael/school/3EHIF/DBI/Garlic/database/mysql/data/sm_socialmedias.csv'
into table sm_socialmedias
fields terminated by ','
lines terminated by '\n'
ignore 1 rows;

#csm_connectedsocialmedias
delete from csm_connectedsocialmedias;
load data infile '/Users/michael/school/3EHIF/DBI/Garlic/database/mysql/data/csm_connectedsocialmedias.csv'
into table csm_connectedsocialmedias
fields terminated by ','
lines terminated by '\n'
ignore 1 rows;

#r_rankings
delete from r_rankings;
load data infile '/Users/michael/school/3EHIF/DBI/Garlic/database/mysql/data/r_rankings.csv'
into table r_rankings
fields terminated by ','
lines terminated by '\n'
ignore 1 rows;

#a_articles
delete from a_articles;
load data infile '/Users/michael/school/3EHIF/DBI/Garlic/database/mysql/data/a_articles.csv'
into table a_articles
fields terminated by ','
enclosed by '"'
lines terminated by '\n'
ignore 1 rows;

#c_comments
delete from c_comments;
load data infile '/Users/michael/school/3EHIF/DBI/Garlic/database/mysql/data/c_comments.csv'
into table c_comments
fields terminated by ','
lines terminated by '\n'
ignore 1 rows;

#v_votes
delete from v_votes;
load data infile '/Users/michael/school/3EHIF/DBI/Garlic/database/mysql/data/v_votes.csv'
into table v_votes
fields terminated by ','
lines terminated by '\n'
ignore 1 rows;

set foreign_key_checks = 1;