package entites;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
@Entity
public class Avis implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	int avisId;
	int note;

	@Temporal(TemporalType.DATE)
	Date dateAvis;
	@ManyToOne
	@JoinColumn(name = "usId")
	User user;
	public int getAvisId() {
		return avisId;
	}
	public void setAvisId(int avisId) {
		this.avisId = avisId;
	}
	public int getNote() {
		return note;
	}
	public void setNote(int note) {
		this.note = note;
	}
	public Date getDateAvis() {
		return dateAvis;
	}
	public void setDateAvis(Date dateAvis) {
		this.dateAvis = dateAvis;
	}
	public User getUser() {
		return user;
	}
	public void setUser(User user) {
		this.user = user;
	}
	public Entreprise getEntreprise() {
		return entreprise;
	}
	public void setEntreprise(Entreprise entreprise) {
		this.entreprise = entreprise;
	}
	@ManyToOne
	@JoinColumn(name = "entId")
	Entreprise entreprise;
	
}
