package managedBeans;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.enterprise.context.RequestScoped;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

import entites.Entreprise;
import entites.Reclamation;
import services.EntrepriseService;
import services.ReclamationService;

@ManagedBean(name = "ReclamationBean")
@RequestScoped
public class ReclamationBean implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private String description;
	private Date date = Calendar.getInstance().getTime();
	private Reclamation re = new Reclamation();
	private Entreprise e = new Entreprise();
	private int i;
	private ArrayList<Entreprise> ee= new ArrayList<Entreprise>();
	public Entreprise getE() {
		return e;
	}
	public ArrayList<Entreprise> getEe() {
		return ee;
	}
	public void setEe(ArrayList<Entreprise> ee) {
		this.ee = ee;
	}
	public void setE(Entreprise e) {
		this.e = e;
	}


	@EJB
	ReclamationService rs = new ReclamationService();
	@EJB
	EntrepriseService es = new EntrepriseService();
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public Date getDate() {
		return date;
	}
	public void setDate(Date date) {
		this.date = date;
	}

	
	
	public Reclamation getRe() {
		return re;
	}
	public void setRe(Reclamation re) {
		this.re = re;
	}
	public String ajout() {
		
		re.setDateRec(date);
		re.setDescription(description);
		re.setEntreprise(es.getEntrepriseById(i));
		UserBean ub = new UserBean();
		re.setUser(ub.getUser());
		rs.ajouterReclamation(re);
		return "/pages/Entreprises.jsf?face-redirect=true";
	}
	
	@PostConstruct
	public void init() {ee=es.getall();}
	public int getI() {
		return i;
	}
	public void setI(int i) {
		this.i = i;
	}
	
	
	

}
