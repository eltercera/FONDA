package com.ds201625.fonda.logic.Commands.OrderCommands;

import android.os.Message;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.EmailService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Email;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;


/**
 * Created by Jessica on 22/6/2016.
 */
public class EmailCommand extends BaseCommand {

    private String TAG = "EmailCommand";
    private Email emailCommensal;
    private String mailhost = "smtp.gmail.com";
    private Invoice invoice;

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[1];
        parameters[0] = new Parameter(Email.class, true);
        return parameters;
    }

    @Override
    protected void invoke() throws Exception {
        EmailService emailService = FondaServiceFactory.getInstance().getEmailService();

        emailCommensal = FondaEntityFactory.getInstance().GetEmail();

/*        try{
            emailCommensal = (Email) getParameter(0);
            Message message = new Message();
            message.setRecipients(Message.RecipientType.TO,
                    InternetAddress.parse(emailCommensal.getEmail());
            message.setSubject("Testing Subject");
            message.setText(invoice);

            Transport.send(message);

        }*/
    }
}
