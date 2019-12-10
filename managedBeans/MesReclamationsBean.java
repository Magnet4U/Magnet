package managedBeans;

import java.io.Serializable;
import java.util.ArrayList;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.enterprise.context.RequestScoped;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

import entites.Reclamation;
import services.ReclamationService;

@ManagedBean(name = "MesReclamationsBean")
@RequestScoped
public class MesReclamationsBean implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private ArrayList<Reclamation> ee= new ArrayList<Reclamation>();
@EJB
ReclamationService rs;
public ArrayList<Reclamation> getEe() {
	return ee;
}
public void setEe(ArrayList<Reclamation> ee) {
	this.ee = ee;
}
public void delete(int id)
{rs.supprimer(id);}
@PostConstruct
public void init() {UserBean ub = new UserBean();
	ee=rs.getRec(ub.getUser().getUserId());}
}
