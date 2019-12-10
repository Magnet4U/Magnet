package managedBeans;

import java.io.Serializable;

import javax.ejb.EJB;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;

import entites.User;
import services.UserService;

@ManagedBean(name = "UserBean")
@SessionScoped
public class UserBean implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private String login;
	private String password;
	private static User user;
	@EJB
	UserService us;
	
	public String getLogin() {
		return login;
	}

	public void setLogin(String login) {
		this.login = login;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public static User getUser() {
		return user;
	}

	public static void setUser(User user) {
		UserBean.user = user;
	}

	public String doLogin() {
		String navigateTo = "null";
		user = us.getEmployeByEmailAndPassword(login, password);
		if (user != null) {
			if (user.getRole()==1)
			{navigateTo = "/pages/Entreprises.jsf?face-redirect=true";}
			else {navigateTo="/pages/Entreprises1.jsf?face-redirect=true";}
			FacesContext.getCurrentInstance().addMessage("form:btn", new FacesMessage("aaslema"));
			
		} else {
			FacesContext.getCurrentInstance().addMessage("form:btn", new FacesMessage("Bad Credentials "+login+"+"+password));
			
			
		}
		return navigateTo;
	}

}
