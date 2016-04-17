package com.ds201625.fonda.views.activities;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

import java.util.ArrayList;

/**
 * Adaptador base para contener los Fragments para las Activities con
 * Tabs
 */
public class BaseSectionsPagerAdapter extends FragmentPagerAdapter {

    /**
     * Array de Fragments
     */
    private ArrayList<Fragment> fragments;

    /**
     * Array de strings con los titulos.
     */
    private ArrayList<String> titles;

    /**
     * Constructor
     * @param fm
     */
    public BaseSectionsPagerAdapter(FragmentManager fm) {
        super(fm);
        fragments = new ArrayList<Fragment>();
        titles = new ArrayList<String>();
    }

    /**
     * Agrega un Fragment
     * @param title
     * @param fm
     */
    public void addFragment(String title, Fragment fm) {
        fragments.add(fm);
        titles.add(title);
        notifyDataSetChanged();
    }

    @Override
    public Fragment getItem(int position) {
        return fragments.get(position);
    }

    @Override
    public int getCount() {
        return fragments.size();
    }

    @Override
    public CharSequence getPageTitle(int position) {
        return titles.get(position);
    }
}
