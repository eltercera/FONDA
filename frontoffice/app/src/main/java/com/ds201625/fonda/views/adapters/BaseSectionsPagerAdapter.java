package com.ds201625.fonda.views.adapters;

import android.graphics.drawable.Drawable;
import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.text.SpannableString;
import android.text.Spanned;
import android.text.style.ImageSpan;

import com.ds201625.fonda.R;

import java.util.ArrayList;

/**
 * Adaptador base para contener los Fragments para las Activities con
 * Tabs
 */
public class BaseSectionsPagerAdapter extends FragmentPagerAdapter {

    private ArrayList<Integer> tabNumber;

    /**
     * Array de Fragments
     */
    private ArrayList<Fragment> fragments;

    /**
     * Array de strings con los titulos.
     */
    private ArrayList<String> titles;

    private ArrayList<Drawable> icons;
    private TabLayout tabLayout;

    /**
     * Constructor
     * @param fm
     */
    public BaseSectionsPagerAdapter(FragmentManager fm, TabLayout tabLayout) {
        super(fm);
        fragments = new ArrayList<Fragment>();
        titles = new ArrayList<String>();
        icons = new ArrayList<Drawable>();
        this.tabLayout = tabLayout;
    }

    public BaseSectionsPagerAdapter(FragmentManager fm) {
        super(fm);
        fragments = new ArrayList<Fragment>();
        titles = new ArrayList<String>();
        icons = new ArrayList<Drawable>();
        tabLayout = null;
     }


    /**
     * Agrega un Fragment
     * @param title
     * @param fm
     */
    public void addFragment(String title, Fragment fm) {
        fragments.add(fm);
        titles.add(title);
        icons.add(null);
        notifyDataSetChanged();
    }

    public void addFragment(Drawable titleIcon, Fragment fm) {
        if (tabLayout == null)
            return;
        fragments.add(fm);
        titles.add("");
        icons.add(titleIcon);
        notifyDataSetChanged();
    }


    public void addFragment(String title, Drawable titleIcon, Fragment fm) {
        if (tabLayout == null)
            return;
        fragments.add(fm);
        titles.add(title);
        icons.add(titleIcon);
        notifyDataSetChanged();
    }

    public void iconsSetup() {
        notifyDataSetChanged();
        for(int i = 0; i<fragments.size() ; i++) {
            Drawable icon = icons.get(i);
            if (icon != null) {
                tabLayout.getTabAt(i).setIcon(icon);
            }
        }
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
