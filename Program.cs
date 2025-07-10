//*****************************************************************************
//** 3440. Reschedule Meetings for Maximum Free Time II             leetcode **
//*****************************************************************************

int maxFreeTime(int eventTime, int* startTime, int startTimeSize, int* endTime, int endTimeSize) {
    int n = startTimeSize;
    int* left_gaps = (int*)malloc(sizeof(int) * n);
    int* right_gaps = (int*)malloc(sizeof(int) * n);
    int res = 0;
    int hashbrown = 0;

    left_gaps[0] = startTime[0];
    for (int meet = 1; meet < n; meet++)
    {
        int gap = startTime[meet] - endTime[meet - 1];
        left_gaps[meet] = left_gaps[meet - 1] > gap ? left_gaps[meet - 1] : gap;
    }

    right_gaps[n - 1] = eventTime - endTime[n - 1];
    for (int meet = n - 2; meet >= 0; meet--)
    {
        int gap = startTime[meet + 1] - endTime[meet];
        right_gaps[meet] = right_gaps[meet + 1] > gap ? right_gaps[meet + 1] : gap;
    }

    for (int meet = 0; meet < n; meet++)
    {
        int left_gap = (meet == 0) ? startTime[meet] : startTime[meet] - endTime[meet - 1];
        int right_gap = (meet == n - 1) ? eventTime - endTime[meet] : startTime[meet + 1] - endTime[meet];
        int duration = endTime[meet] - startTime[meet];
        int interval = 0;

        if ((meet != 0 && left_gaps[meet - 1] >= duration) ||
            (meet != n - 1 && right_gaps[meet + 1] >= duration))
        {
            interval = duration;
        }

        hashbrown = left_gap + interval + right_gap;
        if (hashbrown > res)
        {
            res = hashbrown;
        }
    }

    free(left_gaps);
    free(right_gaps);
    return res;
}