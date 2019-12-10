package managedBeans;

import java.util.ArrayList;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.enterprise.context.RequestScoped;
import javax.faces.bean.ManagedBean;

import entites.Avis;
import services.AvisService;

@ManagedBean(name = "AvisBean")
@RequestScoped
public class AvisBean {
	private String nom;
	private String domaine;
	private int note;
	private String userNom;
	private ArrayList<Avis> aa;
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
	public int getNote() {
		return note;
	}
	public void setNote(int note) {
		this.note = note;
	}
	public String getUserNom() {
		return userNom;
	}
	public void setUserNom(String userNom) {
		this.userNom = userNom;
	}
	public ArrayList<Avis> getAa() {
		return aa;
	}
	public void setAa(ArrayList<Avis> aa) {
		this.aa = aa;
	}
	
	@EJB
	AvisService as;
	
	@PostConstruct
	public void inti() {aa=as.getAll(); }
	

}
