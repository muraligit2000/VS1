
drop table emp
drop table dept


create table dept(   
  deptno     int,   
  dname      varchar(50),   
  loc        varchar(50),   
  constraint pk_dept primary key (deptno, loc)   
)
go
create table emp(   
  empno    int,   
  ename    varchar(50),   
  job      varchar(50),   
  mgr      int,   
  hiredate datetime,   
  sal      int,   
  comm     int,   
  deptno   int,   
  loc varchar(50),
  constraint pk_emp primary key (empno),   
  constraint fk_deptno foreign key (deptno, loc) references dept (deptno, loc)   
)
go
SElECT * FROM EMP order by deptno
SElECT * FROM DEPT

-- added a new column to the db
----- case 1 : column NOT NULL
----- case 2 : column NULL
-- delete a column from the db table
-- column data type is changed from the db table
----- case 1 : database int -> varchar
----- case 2 : database varchar -> int

alter table emp add loc varchar(50)

Update emp set loc = 'DALLAS'

Update emp set loc = 'NEW YORK' where deptno = 10
Update emp set loc = 'DALLAS' where deptno = 20
Update emp set loc = 'CHICAGO' where deptno = 30



drop view EMP_DEPT

CREATE VIEW EMP_DEPT AS
SELECT EMP.*, DEPT.deptno DEPT_DEPTNO, DEPT.dname FROM EMP FULL JOIN DEPT ON EMP.DEPTNO = DEPT.DEPTNO 

SELECT * FROM EMP_DEPT ORDER BY DEPTNO 

CREATE VIEW EMP_DEPT AS
SELECT EMP.*, DEPT.deptno DEPT_DEPTNO, DEPT.dname, DEPT.loc 
FROM EMP 
--INNER JOIN 
--LEFT JOIN 
--RIGHT JOIN
FULL JOIN
DEPT 
ON EMP.DEPTNO = DEPT.DEPTNO 





uPDATE EMP SET DEPTNO = NULL, loc = null WHERE EMPNO IN(7782,7788)

insert into DEPT (DEPTNO, DNAME, LOC) 
values
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON')
go

insert into emp   
values( 7839, 'KING', 'PRESIDENT', null,   '17-NOV-1981',   5000, null, 10 , 'new york' )



insert into emp  
values(  
 7698, 'BLAKE', 'MANAGER', 7839,  
 '1-MAY-1981',  
 2850, null, 30  , null
)



insert into emp  
values(  
 7782, 'CLARK', 'MANAGER', 7839,  
 '9-JUN-1981',  
 2450, null, 10  , null
)



insert into emp  
values(  
 7566, 'JONES', 'MANAGER', 7839,  
 '2-APR-1981',  
 2975, null, 20  , null
)



insert into emp  
values(  
 7788, 'SCOTT', 'ANALYST', 7566,  
 '13-JUL-87',  
 3000, null, 20  , null
)



insert into emp  
values(  
 7902, 'FORD', 'ANALYST', 7566,  
 '3-DEC-1981',  
 3000, null, 20  , null
)



insert into emp  
values(  
 7369, 'SMITH', 'CLERK', 7902,  
 '17-DEC-1980',  
 800, null, 20  , null
)



insert into emp  
values(  
 7499, 'ALLEN', 'SALESMAN', 7698,  
 '20-FEB-1981',  
 1600, 300, 30  , null
)



insert into emp  
values(  
 7521, 'WARD', 'SALESMAN', 7698,  
 '22-FEB-1981',  
 1250, 500, 30  , null
)



insert into emp  
values(  
 7654, 'MARTIN', 'SALESMAN', 7698,  
 '28-SEP-1981',  
 1250, 1400, 30  , null
)



insert into emp  
values(  
 7844, 'TURNER', 'SALESMAN', 7698,  
 '8-SEP-1981',  
 1500, 0, 30  , null
)



insert into emp  
values(  
 7876, 'ADAMS', 'CLERK', 7788,  
 '13-JUL-87',  
 1100, null, 20  , null
)



insert into emp  
values(  
 7900, 'JAMES', 'CLERK', 7698,  
 '3-DEC-1981',  
 950, null, 30  , null
)



insert into emp  
values(  
 7934, 'MILLER', 'CLERK', 7782,  
 '23-JAN-1982',  
 1300, null, 10  , null
)
















