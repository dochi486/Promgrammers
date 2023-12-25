#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int solution(vector<int> dot) {
    int answer = 0;

    int x = dot[0], y = dot[1];
    if(x > 0) {
        if(y > 0) return 1;
        else return 4;
    }
    else {
        if(y > 0) return 2;
        else return 3;
    }

    return answer;
}

int main()
{
    std::cout << "Hello, World!" << std::endl;

    return 0;
}


