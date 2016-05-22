package com.ds201625.fonda.tests.commensal_tests;

/*import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.CoreMatchers.*;*/
import static org.mockito.Mockito.*;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.runners.MockitoJUnitRunner;
import android.content.SharedPreferences;
import android.content.pm.PackageInstaller;

import com.ds201625.fonda.data_access.retrofit_client.clients.RetrofitService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.logic.SessionData;

/**
 * Created by gbsoj on 5/22/2016.
 */

@RunWith(MockitoJUnitRunner.class)
public class CommensalTests {

    private static final Commensal commensal = new Commensal();

    public CommensalTests () {
        commensal.setEmail("admin@admin.com");
        commensal.setPassword("123456");
    }

    @Mock
    Context mMockContext;

    @Test
    public void getLoggedCommensal() {

        when(SessionData.getInstance().getCommensal())
                .thenReturn(commensal);

        Commensal result = SessionData.getInstance().getCommensal();

        assertThat(result, is(commensal));
    }

/*    @Test
    public void removeLoggedCommensal() {
        try {
            SessionData.getInstance().logoutCommensal();
        }
        catch (Exception e){
            e.printStackTrace();
        }

        Commensal result = SessionData.getInstance().getCommensal();

        assertThat(result, is(null));

    }*/
}
