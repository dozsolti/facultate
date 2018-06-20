// ConsoleApplication66.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"
#include <iostream>
using namespace std;

struct nod {
	int n;
	nod* next;
};

void Prepend(nod* &list, int x) {
	nod* New = new nod;
	New->n=x;
	New->next = list;
	list = New;
	/*nod* start = list;
	for (; list->next != NULL; list = list->next);  //t; lista circulara
	list->next = start;
	
	*/

}
void Append(struct nod* &list, int x)
{
	nod* t = list;
	for (; t->next != NULL; t = t->next);
	nod* New = new nod;
	New->n=x;
	New->next = NULL;  //t; lista circulara
	t->next = New;
}
void Print(nod* &list) {
	nod* t;
	for (t = list; t != NULL; t = t->next)
		cout << t->n << "  ";
	cout << "\n";
}
void StergereLaInceput(struct nod* &list)
{
	list = list->next;
}
void StergereLaSfarsit(struct nod* &list)
{
	nod* t = list;
	for (; t->next->next != NULL; t = t->next);
	t->next = NULL;
}

int main()
{
	nod* p = NULL;
	Prepend(p, 2);
	Prepend(p, 3);
	Append(p, 1);
	Append(p, 0);
	Print(p);
	StergereLaInceput(p);
	StergereLaSfarsit(p);
	Print(p);
	system("pause");
    return 0;
}

