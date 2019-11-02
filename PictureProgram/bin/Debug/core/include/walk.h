#include <stdio.h>
#include <stdlib.h>
#include <string.h>
void walk(int *x,int *y,char a[500][500],char b[50])
{   
    char ch;
    int s,z,i,xa,ya;
    
    xa=*x; ya=*y;
    s=strlen(b);
    ch=getch();
    if(ch=='s')
    {
        for(z=0;z!=s;z++)
        {
          if(a[xa+1][ya]==b[z])
          break;
        }  
        if(z==s)
        {
            a[xa][ya]=' ';
            xa++;
            a[xa][ya]='O';
        }
    }
    if(ch=='w')
    {
		for(z=0;z!=s;z++)
        {
          if(a[xa-1][ya]==b[z])
          break;
        }  
		if(z==s)
		{
		    a[xa][ya]=' ';
		    xa--;
		    a[xa][ya]='O';
		}
    }
    if(ch=='a')
    {
        for(z=0;z!=s;z++)
        {
          if(a[xa][ya-1]==b[z])
          break;
        }  
		if(z==s)
		{
		    a[xa][ya]=' ';
		    ya--;
		    a[xa][ya]='O';
		}
    }
    if(ch=='d')
    {
		for(z=0;z!=s;z++)
        {
          if(a[xa][ya+1]==b[z])
          break;
        }
		if(z==s)
		{
		    a[xa][ya]=' ';
		    ya++;
		    a[xa][ya]='O';
		}
    }
    system("cls");
    for(i=0;i<=5;i++)
    puts(a[i]);
    *x=xa; *y=ya;
}
