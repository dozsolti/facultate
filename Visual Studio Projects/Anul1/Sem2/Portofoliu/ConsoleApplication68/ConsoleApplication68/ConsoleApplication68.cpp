#include "stdafx.h"
#include <iostream>
using namespace std;

struct cavaler {
	int n;
	cavaler* next;
};


void Append(struct cavaler* &old, int i)
{
	if (old == NULL) {
		cavaler* New = new cavaler;
		New->n = i;
		New->next = NULL;
		old = New;
		return;
	}
	cavaler* t = old;
	for (; t->next != NULL; t = t->next);
	cavaler* New = new cavaler;
	New->n = i;
	New->next = NULL;
	t->next = New;
}
void Print(cavaler* &list) {
	cavaler* t;
	for (t = list; t != NULL; t = t->next)
	{
		cout << t->n << "  ";
	}
	cout << "\n";
}
void StergereLaInceput(struct cavaler* &old)
{
	cavaler* t = old;
	old = old->next;
	delete t;
}

void Elimina(cavaler* &list, int k) {
	cavaler* t;
	int i = 0;
	k--;
	for (t = list; i<k; t = t->next, i++);
	t->next = t->next->next;
}
int main()
{
	cavaler* p = NULL;
	for (int i = 1; i <= 12; i++)
		Append(p, i);

	Print(p);
	Elimina(p, 1);
	Print(p);
	Elimina(p, 2);
	Print(p);
	Elimina(p, 5);
	Print(p);

	int j = 1;
	while (p->next != NULL) {
		Elimina(p, j);
		//j=?
	}

	//cout<<p->n<<endl;
	system("pause");
	return 0;
}

// 1,2,3,4,5,6,7,8,9
// 1,3,4,5,6,7,8,9
// 1,3,5,6,7,8,9
// 1,3,5,6,7,9