// ConsoleApplication66.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"
#include <iostream>
using namespace std;

struct nod {
	int n;
	nod* next;
};

void Prepend(nod* &old, int x) {
	nod* New = new nod;
	New->n=x;
	New->next = old;
	old = New;
}
void Print(nod* &list) {
	nod* t;
	for (t = list; t != NULL; t = t->next)
	{
		cout << t->n << "  ";
	}
	cout << "\n";
}
void StergereLaInceput(struct nod* &old)
{
	nod* t = old;
	old = old->next;
	delete t;
}

int main()
{
	nod* p = NULL;
	Prepend(p, 1);
	Prepend(p, 2);
	Print(p);
	system("pause");
    return 0;
}

