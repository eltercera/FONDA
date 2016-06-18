package com.ds201625.fonda.views.adapters;

import com.ds201625.fonda.R;

/**
 * Created by gbsojo on 6/8/2016.
 */
public enum PagerEnum {

    /*GLOBAL(R.drawable.ic_global_brown_24dp,R.layout.list_restaurant),
    FOOD(R.drawable.ic_food_primary_24dp, R.layout.list_restaurant),
    ZONE(R.drawable.ic_place_primary_24dp, R.layout.list_restaurant);*/

    GLOBAL(R.string.filter_global,R.layout.list_restaurant),
    FOOD(R.string.filter_food, R.layout.list_restaurant),
    ZONE(R.string.filter_zone, R.layout.list_restaurant);

    private int mTitleResId;
    private int mLayoutResId;

    PagerEnum(int titleResId, int layoutResId) {
        mTitleResId = titleResId;
        mLayoutResId = layoutResId;
    }

    public int getTitleResId() {
        return mTitleResId;
    }

    public int getLayoutResId() {
        return mLayoutResId;
    }
}
