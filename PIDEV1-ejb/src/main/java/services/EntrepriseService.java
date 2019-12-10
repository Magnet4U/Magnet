package services;

import java.util.ArrayList;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.TypedQuery;


import entites.Entreprise;



@Stateless
@LocalBean
public class EntrepriseService {
	@PersistenceContext(unitName = "primary")
	EntityManager em;
	public void ajouterEntreprise(Entreprise p) {em.persist(p);}
	public void supprimer(int id )
	{
		Entreprise entity = new Entreprise();
		Query query =
				em.createQuery("SELECT e FROM Entreprise e WHERE e.entrepriseId=:id  ",
						Entreprise.class);
				query.setParameter("id", id);
			entity=(Entreprise) query.getSingleResult();
		em.remove(entity);
	}
	public ArrayList<Entreprise>  getall() {
		ArrayList<Entreprise> p ;
		TypedQuery<Entreprise> query = em
				.createQuery("select c from Entreprise AS c", Entreprise.class);
		
			p = (ArrayList<Entreprise>) query.getResultList();
			return p;
	

	}
	public Entreprise getEntrepriseById(int id) {TypedQuery<Entreprise> query = em
			.createQuery("select e from Entreprise e where e.entrepriseId=:id", Entreprise.class);
	query.setParameter("id", id);
	Entreprise e = null;
	e = query.getSingleResult();
	return e;}
	public Entreprise getEntrepriseByNom(String nom) {TypedQuery<Entreprise> query = em
			.createQuery("select e from Entreprise e where e.nom=:nom", Entreprise.class);
	query.setParameter("nom", nom);
	Entreprise e = null;
	e = query.getSingleResult();
	return e;}
}
