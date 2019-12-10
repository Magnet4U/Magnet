package managedBeans;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Calendar;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.enterprise.context.RequestScoped;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.persistence.TypedQuery;

import entites.Avis;
import entites.Entreprise;
import entites.User;
import services.AvisService;
import services.EntrepriseService;

@ManagedBean(name = "EntrepriseBean")
@RequestScoped
public class EntrepriseBean implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
private String nom;
private String domaine;
private User user;
private int note ;
public User getUser() {
	return user;
}



public void setUser(User user) {
	this.user = user;
}



private ArrayList<Entreprise> e;

	
	
	public ArrayList<Entreprise> getE() {
	return e;
}



public void setE(ArrayList<Entreprise> e) {
	this.e = e;
}



	public String getNom() {
	return nom;
}



public void setNom(String nom) {
	this.nom = nom;
}



public String getDomaine() {
	return domaine;
}



public void setDomaine(String domaine) {
	this.domaine = domaine;
}



	@EJB
	EntrepriseService es;
	@EJB
	AvisService as;
	public void delete (int id) {es.supprimer(id);}
	public String noter (int id ) {Avis aa = new Avis();
	aa.setDateAvis(Calendar.getInstance().getTime());
	aa.setEntreprise(es.getEntrepriseById(id));
	aa.setNote(note);
	if(note>5) {return "/pages/Avis.jsf?face-redirect=true";} 
	UserBean ub = new UserBean();
	aa.setUser(ub.getUser());

	as.ajouterAvis(aa);
	return "/pages/Avis.jsf?face-redirect=true";
	
	}
	@PostConstruct
	public void init() {e=es.getall();}



	public int getNote() {
		return note;
	}



	public void setNote(int note) {
		this.note = note;
	}
	public float moyenne (int id ) {return as.moy(id);}
}
