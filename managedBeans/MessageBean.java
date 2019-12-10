package managedBeans;

import java.util.ArrayList;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.enterprise.context.RequestScoped;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

import entites.Entreprise;
import entites.Message1;
import entites.User;
import services.EntrepriseService;
import services.MessageService;

@ManagedBean(name = "MessageBean")
@RequestScoped
public class MessageBean {
	private ArrayList<Message1> m;
	private String nom;
	private String text;
	UserBean ub = new UserBean();
	@EJB
	MessageService ms;
	@EJB
	EntrepriseService es;
	public ArrayList<Message1> getM() {
		return m;
	}

	public void setM(ArrayList<Message1> m) {
		this.m = m;
	}

	public String getNom() {
		return nom;
	}

	public void setNom(String nom) {
		this.nom = nom;
	}

	public String getText() {
		return text;
	}

	public void setText(String text) {
		this.text = text;
	}
	public String add()
	{Message1 m = new Message1();
	Entreprise e = new Entreprise();
	Message1 m1 = new Message1();
	m.setContenu(text);
	e=es.getEntrepriseByNom(nom);
	m.setUser_dest_id(e.getUser().getUserId());
	m.setUser_sender(ub.getUser());
	m1.setContenu("Votre demande est en cours de traitement");
	m1.setUser_dest_id(ub.getUser().getUserId());
	m1.setUser_sender(e.getUser());
	
	ms.envoyerMessage(m);
	ms.envoyerMessage(m1);
	return "/pages/forum.jsf?face-redirect=true";
	}

	@PostConstruct
	public void init() {m=ms.getall(ub.getUser().getUserId());}
}
