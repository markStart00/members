#! /bin/sh

# run stored procedures

/opt/mssql-tootls/bin/sqlcmd -S sqlexpress -U sa -P password -d MembersDb -i /init-scripts/stored-procedures.sql


# run the seed data script

/opt/mssql-tootls/bin/sqlcmd -S sqlexpress -U sa -P password -d MembersDb -i /init-scripts/seed-data.sql


